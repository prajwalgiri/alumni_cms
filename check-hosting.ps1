# ===========================
# check-hosting.ps1 (Win10) - FE + BE IIS health check (STATIC or IISNODE)
# Exit codes: 0 OK, 1 WARN, 2 FAIL
# ===========================

param([string]$JsonOut = "")

Set-StrictMode -Version Latest
$ErrorActionPreference = "Continue"

# -------- CONFIG --------
$HostToTest = "localhost"

# FE
$FeSiteName = "AlumniCMS"
$FeDeployDir = "C:\deploy\alumni\alumni-fe"
$FePort = 3000

# FE mode: "STATIC" or "IISNODE"
$FeMode = "STATIC"
$FeNodeEntry = "server.js"   # only used if IISNODE

# BE
$BeSiteName = "AlumniCMS_API"
$BeDeployDir = "C:\deploy\alumni\alumni-be"
$BePort = 3002

# Optional proxy test (from FE)
$ApiHealthPath = "/api/health"   # "" to skip

# Requirements
$RequireIisSitesExist = $true
$RequireFeHttp200 = $true
$RequireBeSiteExists = $true
# ------------------------

$RESULT = [ordered]@{
    timestamp = (Get-Date).ToString("o")
    host      = $HostToTest
    fe        = [ordered]@{ site = $FeSiteName; port = $FePort; path = $FeDeployDir; mode = $FeMode; nodeEntry = $FeNodeEntry }
    be        = [ordered]@{ site = $BeSiteName; port = $BePort; path = $BeDeployDir }
    checks    = @()
    summary   = [ordered]@{ ok = 0; warn = 0; fail = 0 }
    exitCode  = 0
}

function Add-Check([string]$name, [string]$status, [string]$message, [hashtable]$data = $null) {
    $RESULT.checks += [ordered]@{ name = $name; status = $status; message = $message; data = $data }
    switch ($status) {
        "OK" { $RESULT.summary.ok++ }
        "WARN" { $RESULT.summary.warn++ }
        "FAIL" { $RESULT.summary.fail++ }
    }
}

function Title($t) { Write-Host "`n=== $t ===" -ForegroundColor Cyan }
function Ok($m) { Write-Host "[OK]   $m" -ForegroundColor Green }
function Warn($m) { Write-Host "[WARN] $m" -ForegroundColor Yellow }
function Err($m) { Write-Host "[ERR]  $m" -ForegroundColor Red }

function Test-PathSafe([string]$p) { try { return (Test-Path -LiteralPath $p) } catch { return $false } }
function Read-TextFile([string]$p) { try { return (Get-Content -LiteralPath $p -Raw -ErrorAction Stop) } catch { return $null } }

function Get-HttpStatus([string]$url) {
    try {
        $r = Invoke-WebRequest -Uri $url -UseBasicParsing -TimeoutSec 10
        return @{ ok = $true; status = [int]$r.StatusCode; len = ($r.Content.Length); content = $r.Content }
    }
    catch {
        $status = $null
        try { $status = $_.Exception.Response.StatusCode.value__ } catch {}
        return @{ ok = $false; status = $status; err = $_.Exception.Message; content = $null }
    }
}

function Ensure-WebAdminLoaded {
    if (-not (Get-Module -ListAvailable -Name WebAdministration)) {
        Add-Check "iis.webadministration" "FAIL" "WebAdministration module not found."
        return $false
    }
    try {
        Import-Module WebAdministration -ErrorAction Stop | Out-Null
        Add-Check "iis.webadministration" "OK" "WebAdministration loaded."
        return $true
    }
    catch {
        Add-Check "iis.webadministration" "FAIL" ("Failed to import WebAdministration: " + $_.Exception.Message)
        return $false
    }
}

function Get-IisSite([string]$name) {
    try { if (Test-Path "IIS:\Sites\$name") { return (Get-Item "IIS:\Sites\$name") } } catch {}
    return $null
}

function Check-Site([string]$siteName, [string]$kind) {
    $site = Get-IisSite $siteName
    if (-not $site) { Add-Check "$kind.iis.site" "FAIL" "IIS site not found." @{ site = $siteName }; return }
    Add-Check "$kind.iis.site" "OK" ("IIS site found (state={0})." -f $site.State) @{ site = $siteName; path = $site.physicalPath }
    $bindings = @($site.Bindings.Collection | ForEach-Object { "$($_.protocol) $($_.bindingInformation)" })
    Add-Check "$kind.iis.bindings" "OK" ("Bindings={0}" -f $bindings.Count) @{ bindings = $bindings }
}

function Test-UrlRewriteArr {
    $cfg = "$env:windir\System32\inetsrv\config\applicationHost.config"
    if (-not (Test-PathSafe $cfg)) { Add-Check "iis.modules" "WARN" "applicationHost.config missing."; return }

    $c = Read-TextFile $cfg
    if (-not $c) { Add-Check "iis.modules" "WARN" "Could not read applicationHost.config."; return }

    $rewrite = ($c -match "rewrite")
    $arr = ($c -match "applicationRequestRouting" -or $c -match "<section name=`"proxy`"")

    if ($rewrite) { Add-Check "iis.urlRewrite" "OK" "URL Rewrite appears installed." @{} }
    else { Add-Check "iis.urlRewrite" "WARN" "URL Rewrite NOT detected." @{} }

    if ($arr) { Add-Check "iis.arr" "OK" "ARR/Proxy appears installed." @{} }
    else { Add-Check "iis.arr" "WARN" "ARR/Proxy NOT detected." @{} }
}

function Test-ANCM {
    $ancm = "$env:windir\System32\inetsrv\aspnetcorev2.dll"
    if (Test-PathSafe $ancm) { Add-Check "be.ancm" "OK" "ASP.NET Core Module present." @{ path = $ancm } }
    else { Add-Check "be.ancm" "WARN" "ASP.NET Core Module missing (install Hosting Bundle)." @{ expected = $ancm } }
}

function Test-NodeIisNode {
    # node
    try { $null = Get-Command node -ErrorAction Stop; Add-Check "fe.node" "OK" "Node is in PATH." @{} }
    catch { Add-Check "fe.node" "WARN" "Node not found in PATH." @{} }

    # iisnode dll
    $dlls = @(
        "$env:windir\System32\inetsrv\iisnode.dll",
        "${env:ProgramFiles}\iisnode\iisnode.dll",
        "${env:ProgramFiles(x86)}\iisnode\iisnode.dll"
    )
    $found = $false
    foreach ($d in $dlls) { if (Test-PathSafe $d) { $found = $true; break } }
    if ($found) { Add-Check "fe.iisnode" "OK" "iisnode appears installed." @{} }
    else { Add-Check "fe.iisnode" "WARN" "iisnode NOT detected." @{} }

    $entryAbs = Join-Path $FeDeployDir $FeNodeEntry
    if (Test-PathSafe $entryAbs) { Add-Check "fe.nodeEntry" "OK" "Node entry exists." @{ path = $entryAbs } }
    else { Add-Check "fe.nodeEntry" "FAIL" "Node entry missing." @{ expected = $entryAbs } }
}

function Check-FeStaticFiles {
    $idx = Join-Path $FeDeployDir "index.html"
    if (Test-PathSafe $idx) { Add-Check "fe.index" "OK" "index.html present." @{ path = $idx } }
    else { Add-Check "fe.index" "FAIL" "index.html missing." @{ expected = $idx } }
}

function Check-BeFiles {
    $webConfig = Join-Path $BeDeployDir "web.config"
    if (Test-PathSafe $webConfig) { Add-Check "be.webconfig" "OK" "BE web.config present." @{ path = $webConfig } }
    else { Add-Check "be.webconfig" "FAIL" "BE web.config missing (IIS hosting will fail)." @{ expected = $webConfig } }
}

function Check-Http([string]$name, [string]$url, [bool]$requireOk) {
    $r = Get-HttpStatus $url
    if ($r.ok) { Add-Check $name "OK" ("GET {0} -> {1} (len={2})" -f $url, $r.status, $r.len) @{ url = $url; status = $r.status } }
    else {
        $msg = ("GET {0} failed (status={1}) {2}" -f $url, $r.status, $r.err)
        if ($requireOk) { Add-Check $name "FAIL" $msg @{ url = $url; status = $r.status } }
        else { Add-Check $name "WARN" $msg @{ url = $url; status = $r.status } }
    }
}

# ===========================
# RUN
# ===========================
Title "Files"
if (Test-PathSafe $FeDeployDir) { Add-Check "fe.dir" "OK" "FE dir exists." @{ path = $FeDeployDir } } else { Add-Check "fe.dir" "FAIL" "FE dir missing." @{ expected = $FeDeployDir } }
if (Test-PathSafe $BeDeployDir) { Add-Check "be.dir" "OK" "BE dir exists." @{ path = $BeDeployDir } } else { Add-Check "be.dir" "FAIL" "BE dir missing." @{ expected = $BeDeployDir } }

$feWebConfig = Join-Path $FeDeployDir "web.config"
if (Test-PathSafe $feWebConfig) { Add-Check "fe.webconfig" "OK" "FE web.config present." @{ path = $feWebConfig } } else { Add-Check "fe.webconfig" "WARN" "FE web.config missing." @{ expected = $feWebConfig } }

if ($FeMode -eq "STATIC") { Check-FeStaticFiles }
elseif ($FeMode -eq "IISNODE") { Test-NodeIisNode }
else { Add-Check "fe.mode" "FAIL" "Invalid FeMode (use STATIC or IISNODE)." @{ value = $FeMode } }

Check-BeFiles

Title "IIS"
$webAdminOk = Ensure-WebAdminLoaded
if ($webAdminOk) {
    Check-Site $FeSiteName "fe"
    Check-Site $BeSiteName "be"
}

Title "Modules"
Test-UrlRewriteArr
Test-ANCM
if ($FeMode -eq "IISNODE") { Test-NodeIisNode }

Title "HTTP"
$feRoot = "http://$HostToTest`:$FePort/"
$beRoot = "http://$HostToTest`:$BePort/"
Check-Http "http.fe.root" $feRoot $RequireFeHttp200
Check-Http "http.be.root" $beRoot $false

if ($ApiHealthPath -and $ApiHealthPath.Trim() -ne "") {
    $api = "http://$HostToTest`:$FePort$ApiHealthPath"
    Check-Http "http.fe.api" $api $false
}

Title "Summary"
Write-Host ("OK={0} WARN={1} FAIL={2}" -f $RESULT.summary.ok, $RESULT.summary.warn, $RESULT.summary.fail) -ForegroundColor Cyan

# exit code
$requiredFailures = @()
if ($RequireIisSitesExist) { $requiredFailures += @($RESULT.checks | Where-Object { $_.name -in @("fe.iis.site", "be.iis.site") -and $_.status -eq "FAIL" }) }
if ($RequireFeHttp200) { $requiredFailures += @($RESULT.checks | Where-Object { $_.name -eq "http.fe.root" -and $_.status -eq "FAIL" }) }
if ($RequireBeSiteExists) { $requiredFailures += @($RESULT.checks | Where-Object { $_.name -eq "be.iis.site" -and $_.status -eq "FAIL" }) }

$requiredFailures = @($requiredFailures | Where-Object { $_ })

$exit = 0
if ($requiredFailures.Count -gt 0 -or $RESULT.summary.fail -gt 0) { $exit = 2 }
elseif ($RESULT.summary.warn -gt 0) { $exit = 1 }
else { $exit = 0 }

$RESULT.exitCode = $exit

if ($JsonOut -and $JsonOut.Trim() -ne "") {
    try {
        $dir = Split-Path -Parent $JsonOut
        if ($dir -and -not (Test-PathSafe $dir)) { New-Item -ItemType Directory -Force -Path $dir | Out-Null }
        ($RESULT | ConvertTo-Json -Depth 10) | Set-Content -Path $JsonOut -Encoding UTF8
        Ok ("Wrote JSON report: {0}" -f $JsonOut)
    }
    catch {
        Warn ("Could not write JSON report: {0}" -f $_.Exception.Message)
    }
}

exit $exit
