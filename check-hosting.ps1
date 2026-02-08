# ===========================
# check-hosting.ps1 (Verbose, ASCII-safe)
# FE (IISNODE) + BE (IIS)
# Exit codes: 0 OK, 1 WARN, 2 FAIL
# ===========================

param(
    [switch]$VerboseOutput,
    [string]$JsonOut = ""
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Continue"

# -------- CONFIG --------
$HostToTest = "localhost"

# FE
$FeSiteName = "AlumniCMS"
$FeDeployDir = "C:\deploy\alumni\alumni-fe"
$FePort = 3000

# Node entry (iisnode)
# If you use the publish script I gave, it also writes .iisnode-entry.txt
$FeNodeEntryDefault = "build\index.js"

# BE
$BeSiteName = "AlumniCMS_API"
$BeDeployDir = "C:\deploy\alumni\alumni-be"
$BePort = 3002

# Optional proxy health check via FE (if you proxy /api -> BE)
$ApiHealthPath = "/health"
# ------------------------

# Result
$R = [ordered]@{
    timestamp = (Get-Date).ToString("o")
    checks    = @()
    summary   = [ordered]@{ ok = 0; warn = 0; fail = 0 }
    exitCode  = 0
}

function Title([string]$t) {
    Write-Host ""
    Write-Host ("=== {0} ===" -f $t) -ForegroundColor Cyan
}

function TP([string]$p) {
    try { return (Test-Path -LiteralPath $p) } catch { return $false }
}

function Add-Check {
    param(
        [Parameter(Mandatory = $true)][string]$Name,
        [Parameter(Mandatory = $true)][ValidateSet("OK", "WARN", "FAIL")][string]$Status,
        [Parameter(Mandatory = $true)][string]$Message,
        [hashtable]$Data = $null
    )

    $R.checks += [ordered]@{
        name    = $Name
        status  = $Status
        message = $Message
        data    = $Data
    }

    switch ($Status) {
        "OK" { $R.summary.ok++ }
        "WARN" { $R.summary.warn++ }
        "FAIL" { $R.summary.fail++ }
    }

    # Print every check if VerboseOutput is enabled
    if ($VerboseOutput) {
        $color = "Gray"
        if ($Status -eq "OK") { $color = "Green" }
        elseif ($Status -eq "WARN") { $color = "Yellow" }
        elseif ($Status -eq "FAIL") { $color = "Red" }

        Write-Host ("[{0}] {1} - {2}" -f $Status, $Name, $Message) -ForegroundColor $color

        if ($Data) {
            foreach ($kv in $Data.GetEnumerator()) {
                Write-Host ("       {0}: {1}" -f $kv.Key, $kv.Value) -ForegroundColor DarkGray
            }
        }
    }
}

function GetHttp([string]$url) {
    try {
        $resp = Invoke-WebRequest -Uri $url -UseBasicParsing -TimeoutSec 10
        return @{ ok = $true; code = [int]$resp.StatusCode; body = $resp.Content }
    }
    catch {
        $code = $null
        try { $code = $_.Exception.Response.StatusCode.value__ } catch {}
        return @{ ok = $false; code = $code; err = $_.Exception.Message; body = $null }
    }
}

function Detect-FeNodeEntry {
    $marker = Join-Path $FeDeployDir ".iisnode-entry.txt"
    if (TP $marker) {
        try {
            $rel = (Get-Content -LiteralPath $marker -ErrorAction Stop | Select-Object -First 1).Trim()
            if ($rel) { return $rel }
        }
        catch {}
    }
    return $FeNodeEntryDefault
}

# ===========================
# RUN CHECKS
# ===========================

Title "Files"

# FE folder
if (TP $FeDeployDir) {
    Add-Check "fe.dir" "OK" "FE deploy directory exists." @{ path = $FeDeployDir }
}
else {
    Add-Check "fe.dir" "FAIL" "FE deploy directory missing." @{ expected = $FeDeployDir }
}

# FE node entry
$FeNodeEntry = Detect-FeNodeEntry
$feEntryAbs = Join-Path $FeDeployDir $FeNodeEntry
if (TP $feEntryAbs) {
    Add-Check "fe.entry" "OK" "FE IISNODE entry exists." @{ entry = $FeNodeEntry; fullPath = $feEntryAbs }
}
else {
    Add-Check "fe.entry" "FAIL" "FE IISNODE entry missing." @{ expected = $feEntryAbs }
}

# FE web.config
$feWeb = Join-Path $FeDeployDir "web.config"
if (TP $feWeb) {
    Add-Check "fe.webconfig" "OK" "FE web.config present." @{ path = $feWeb }
}
else {
    Add-Check "fe.webconfig" "WARN" "FE web.config missing." @{ expected = $feWeb }
}

# BE folder
if (TP $BeDeployDir) {
    Add-Check "be.dir" "OK" "BE deploy directory exists." @{ path = $BeDeployDir }
}
else {
    Add-Check "be.dir" "FAIL" "BE deploy directory missing." @{ expected = $BeDeployDir }
}

# BE web.config
$beWeb = Join-Path $BeDeployDir "web.config"
if (TP $beWeb) {
    Add-Check "be.webconfig" "OK" "BE web.config present." @{ path = $beWeb }
}
else {
    Add-Check "be.webconfig" "FAIL" "BE web.config missing (IIS hosting will fail)." @{ expected = $beWeb }
}

Title "IIS"

if (Get-Module -ListAvailable WebAdministration) {
    try {
        Import-Module WebAdministration -ErrorAction Stop | Out-Null
        Add-Check "iis.webadmin" "OK" "WebAdministration module loaded."
    }
    catch {
        Add-Check "iis.webadmin" "FAIL" ("Failed to import WebAdministration: {0}" -f $_.Exception.Message)
    }

    foreach ($siteName in @($FeSiteName, $BeSiteName)) {
        $iisPath = "IIS:\Sites\$siteName"
        if (TP $iisPath) {
            try {
                $site = Get-Item $iisPath
                $bindings = @($site.Bindings.Collection | ForEach-Object { "$($_.protocol) $($_.bindingInformation)" })
                Add-Check ("iis.site." + $siteName) "OK" "IIS site exists." @{
                    state        = $site.State
                    physicalPath = $site.physicalPath
                    bindings     = ($bindings -join "; ")
                }
            }
            catch {
                Add-Check ("iis.site." + $siteName) "WARN" ("Could not read site details: {0}" -f $_.Exception.Message)
            }
        }
        else {
            Add-Check ("iis.site." + $siteName) "FAIL" "IIS site not found." @{ site = $siteName }
        }
    }
}
else {
    Add-Check "iis.webadmin" "FAIL" "WebAdministration module not available (IIS tools missing?)."
}

Title "Modules"

$cfg = Join-Path $env:windir "System32\inetsrv\config\applicationHost.config"
if (TP $cfg) {
    $c = $null
    try { $c = Get-Content -LiteralPath $cfg -Raw -ErrorAction Stop } catch {}
    if ($c) {
        if ($c -match "rewrite") {
            Add-Check "iis.urlrewrite" "OK" "URL Rewrite appears installed."
        }
        else {
            Add-Check "iis.urlrewrite" "WARN" "URL Rewrite not detected."
        }

        if ($c -match "applicationRequestRouting" -or $c -match "<section name=`"proxy`"") {
            Add-Check "iis.arr" "OK" "ARR/Proxy appears installed."
        }
        else {
            Add-Check "iis.arr" "WARN" "ARR/Proxy not detected."
        }
    }
    else {
        Add-Check "iis.config.read" "WARN" "Could not read applicationHost.config." @{ path = $cfg }
    }
}
else {
    Add-Check "iis.config" "WARN" "applicationHost.config not found." @{ path = $cfg }
}

# ASP.NET Core module (for BE in IIS)
$ancm = Join-Path $env:windir "System32\inetsrv\aspnetcorev2.dll"
if (TP $ancm) {
    Add-Check "be.ancm" "OK" "ASP.NET Core Module present." @{ path = $ancm }
}
else {
    Add-Check "be.ancm" "WARN" "ASP.NET Core Module missing (install Hosting Bundle)." @{ expected = $ancm }
}

# Node + iisnode
try {
    Get-Command node -ErrorAction Stop | Out-Null
    Add-Check "fe.node" "OK" "Node found in PATH."
}
catch {
    Add-Check "fe.node" "FAIL" "Node not found in PATH."
}

$nodeDlls = @(
    (Join-Path $env:windir "System32\inetsrv\iisnode.dll"),
    (Join-Path ${env:ProgramFiles} "iisnode\iisnode.dll"),
    (Join-Path ${env:ProgramFiles(x86)} "iisnode\iisnode.dll")
)
$foundIisNode = $false
foreach ($d in $nodeDlls) { if ($d -and (TP $d)) { $foundIisNode = $true; break } }

if ($foundIisNode) {
    Add-Check "fe.iisnode" "OK" "iisnode appears installed."
}
else {
    Add-Check "fe.iisnode" "FAIL" "iisnode not detected (iisnode.dll not found)."
}

Title "HTTP"

$feUrl = "http://$HostToTest`:$FePort/"
$r1 = GetHttp $feUrl
if ($r1.ok) {
    Add-Check "http.fe" "OK" "Frontend reachable." @{ url = $feUrl; status = $r1.code }
}
else {
    Add-Check "http.fe" "FAIL" "Frontend NOT reachable." @{ url = $feUrl; status = $r1.code; error = $r1.err }
}

$beUrl = "http://$HostToTest`:$BePort/"
$r2 = GetHttp $beUrl
if ($r2.ok) {
    Add-Check "http.be" "OK" "Backend reachable (direct)." @{ url = $beUrl; status = $r2.code }
}
else {
    Add-Check "http.be" "WARN" "Backend not reachable directly (might still be reachable via IIS site/proxy)." @{ url = $beUrl; status = $r2.code; error = $r2.err }
}

if ($ApiHealthPath -and $ApiHealthPath.Trim() -ne "") {
    $apiUrl = "http://$HostToTest`:$FePort$ApiHealthPath"
    $ra = GetHttp $apiUrl
    if ($ra.ok) {
        Add-Check "http.fe.api" "OK" "API reachable via FE (/api proxy)." @{ url = $apiUrl; status = $ra.code }

        if ($ra.body -and $ra.body.TrimStart().StartsWith("<")) {
            Add-Check "http.fe.api.html" "WARN" "API returned HTML (proxy missing or SPA/SSR fallback caught /api)." @{ url = $apiUrl }
        }
    }
    else {
        Add-Check "http.fe.api" "WARN" "API not reachable via FE (/api proxy)." @{ url = $apiUrl; status = $ra.code; error = $ra.err }
    }
}

Title "Summary"
Write-Host ("OK={0} WARN={1} FAIL={2}" -f $R.summary.ok, $R.summary.warn, $R.summary.fail) -ForegroundColor Cyan

# Exit code
$exit = 0
if ($R.summary.fail -gt 0) { $exit = 2 }
elseif ($R.summary.warn -gt 0) { $exit = 1 }
$R.exitCode = $exit

# JSON output if requested
if ($JsonOut -and $JsonOut.Trim() -ne "") {
    try {
        $parent = Split-Path -Parent $JsonOut
        if ($parent) { Ensure-Dir $parent }
        ($R | ConvertTo-Json -Depth 10) | Set-Content -Path $JsonOut -Encoding UTF8
        if ($VerboseOutput) { Write-Host ("Wrote JSON report: {0}" -f $JsonOut) -ForegroundColor Green }
    }
    catch {
        Add-Check "json.write" "WARN" ("Could not write JSON report: {0}" -f $_.Exception.Message)
    }
}

exit $exit
