# ===========================
# configure-iis-iisnode.ps1 (Windows 10)
# FE: SvelteKit SSR via IISNODE on port 3000
# BE: ASP.NET Core in IIS on port 3002
# ===========================

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

# ---------------------------
# Self-elevate if not admin
# ---------------------------
$IsAdmin = ([Security.Principal.WindowsPrincipal] `
        [Security.Principal.WindowsIdentity]::GetCurrent()
).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)

if (-not $IsAdmin) {
    Write-Host "Restarting script with Administrator privileges..." -ForegroundColor Yellow
    $psi = New-Object System.Diagnostics.ProcessStartInfo
    $psi.FileName = "powershell.exe"
    $psi.Arguments = "-ExecutionPolicy Bypass -File `"$PSCommandPath`""
    $psi.Verb = "runas"
    $psi.UseShellExecute = $true
    try { [System.Diagnostics.Process]::Start($psi) | Out-Null } catch { Write-Error "Admin rights required. UAC was cancelled." }
    exit
}

# -------- CONFIG (edit these) --------
# FE (IISNODE)
$FeSiteName = "AlumniCMS"
$FeAppPool = "AlumniCMS_AppPool"
$FeDeployDir = "C:\deploy\alumni\alumni-fe"
$FePort = 3000
$HostName = ""                 # empty = IP access
$FeNodeEntry = "build\index.js"   # <-- MUST EXIST in $FeDeployDir (adapter-node output)

# Runtime env passed to Node (SvelteKit reads from process.env)
$NodeEnv = "production"
$PublicApiUrl = "http://localhost:3002"   # FE will call this (or proxy /api)

# BE (IIS hosted ASP.NET Core)
$BeSiteName = "AlumniCMS_API"
$BeAppPool = "AlumniCMS_API_AppPool"
$BeDeployDir = "C:\deploy\alumni\alumni-be"
$BePort = 3002

# Proxy /api -> BE (needs URL Rewrite + ARR)
$EnableProxyFromFeToBe = $true

# Firewall
$ConfigureFirewall = $true
# ------------------------------------

function Ensure-Dir([string]$path) {
    if (-not (Test-Path -LiteralPath $path)) { New-Item -ItemType Directory -Force -Path $path | Out-Null }
}
function Info($m) { Write-Host "[INFO] $m" -ForegroundColor Cyan }
function Warn($m) { Write-Host "[WARN] $m" -ForegroundColor Yellow }

function Ensure-IIS_Win10 {
    Info "Ensuring IIS features on Windows 10..."
    $features = @(
        "IIS-WebServerRole",
        "IIS-WebServer",
        "IIS-CommonHttpFeatures",
        "IIS-StaticContent",
        "IIS-DefaultDocument",
        "IIS-HttpErrors",
        "IIS-HttpLogging",
        "IIS-RequestMonitor",
        "IIS-RequestFiltering",
        "IIS-ManagementConsole",
        "IIS-ISAPIFilter",
        "IIS-ISAPIExtensions"
    )

    foreach ($f in $features) {
        $state = Get-WindowsOptionalFeature -Online -FeatureName $f -ErrorAction SilentlyContinue
        if ($null -eq $state) { Warn "Optional feature not found: $f"; continue }
        if ($state.State -ne "Enabled") {
            Info "Enabling feature: $f"
            Enable-WindowsOptionalFeature -Online -FeatureName $f -All -NoRestart | Out-Null
        }
    }
}

function Ensure-WebAdministration {
    if (-not (Get-Module -ListAvailable -Name WebAdministration)) {
        throw "WebAdministration module not available. IIS might not be installed/enabled."
    }
    Import-Module WebAdministration -ErrorAction Stop
}

function Binding-Info([int]$port, [string]$hostHeader) {
    return ("*:{0}:{1}" -f $port, $hostHeader)
}

function Ensure-AppPool([string]$name) {
    if (-not (Test-Path "IIS:\AppPools\$name")) {
        Info "Creating App Pool: $name"
        New-Item "IIS:\AppPools\$name" | Out-Null
    }
    Set-ItemProperty "IIS:\AppPools\$name" -Name managedRuntimeVersion -Value ""
    Set-ItemProperty "IIS:\AppPools\$name" -Name processModel.identityType -Value "ApplicationPoolIdentity"
}

function Ensure-Site([string]$siteName, [string]$appPool, [string]$physicalPath, [int]$port, [string]$hostHeader) {
    Ensure-Dir $physicalPath
    $binding = Binding-Info -port $port -hostHeader $hostHeader

    if (-not (Test-Path "IIS:\Sites\$siteName")) {
        Info ("Creating Site: {0} binding={1} path={2}" -f $siteName, $binding, $physicalPath)
        New-Item "IIS:\Sites\$siteName" -bindings @{ protocol = "http"; bindingInformation = $binding } -physicalPath $physicalPath | Out-Null
    }
    else {
        Info ("Updating Site: {0} -> path={1}, ensuring binding={2}" -f $siteName, $physicalPath, $binding)
        Set-ItemProperty "IIS:\Sites\$siteName" -Name physicalPath -Value $physicalPath

        $site = Get-Item "IIS:\Sites\$siteName"
        $hasBinding = $site.Bindings.Collection | Where-Object { $_.protocol -eq "http" -and $_.bindingInformation -eq $binding }
        if (-not $hasBinding) {
            New-WebBinding -Name $siteName -Protocol "http" -Port $port -HostHeader $hostHeader | Out-Null
        }
    }

    Set-ItemProperty "IIS:\Sites\$siteName" -Name applicationPool -Value $appPool
    Start-WebSite -Name $siteName -ErrorAction SilentlyContinue | Out-Null
}

function Test-NodeInstalled {
    try { Get-Command node -ErrorAction Stop | Out-Null; return $true } catch { return $false }
}

function Test-IisNodeInstalled {
    $candidates = @(
        "$env:windir\System32\inetsrv\iisnode.dll",
        "${env:ProgramFiles}\iisnode\iisnode.dll",
        "${env:ProgramFiles(x86)}\iisnode\iisnode.dll"
    )
    foreach ($p in $candidates) { if (Test-Path -LiteralPath $p) { return $true } }
    return $false
}

function Test-UrlRewriteInstalled {
    $cfg = "$env:windir\System32\inetsrv\config\applicationHost.config"
    if (-not (Test-Path -LiteralPath $cfg)) { return $false }
    (Get-Content $cfg -Raw) -match "rewrite"
}

function Test-ArrInstalled {
    $cfg = "$env:windir\System32\inetsrv\config\applicationHost.config"
    if (-not (Test-Path -LiteralPath $cfg)) { return $false }
    $c = Get-Content $cfg -Raw
    return ($c -match "applicationRequestRouting" -or $c -match "<section name=`"proxy`"")
}

function Write-FeWebConfig_IisNode([string]$path, [string]$nodeEntryRel, [bool]$enableProxy, [int]$bePort, [string]$nodeEnv, [string]$publicApiUrl) {
    $BackendBaseUrl = "http://localhost`:$bePort"

    $proxyRule = ""
    if ($enableProxy) {
        $proxyRule = @"
        <rule name="ReverseProxy_API" stopProcessing="true">
          <match url="^api/(.*)" />
          <action type="Rewrite" url="$BackendBaseUrl/api/{R:1}" />
        </rule>
"@
    }

    $content = @"
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <system.webServer>

    <!-- iisnode handler -->
    <handlers>
      <add name="iisnode" path="$nodeEntryRel" verb="*" modules="iisnode" />
    </handlers>

    <rewrite>
      <rules>
$proxyRule
        <!-- All non-/api requests go to the Node entry -->
        <rule name="NodeApp" stopProcessing="true">
          <match url=".*" />
          <conditions logicalGrouping="MatchAll">
            <add input="{REQUEST_URI}" pattern="^/api" negate="true" />
          </conditions>
          <action type="Rewrite" url="$nodeEntryRel" />
        </rule>
      </rules>
    </rewrite>

    <!-- Node environment variables for SvelteKit -->
    <iisnode
      node_env="$nodeEnv"
      loggingEnabled="true"
      devErrorsEnabled="true"
      flushResponse="true" />

    <environmentVariables>
      <environmentVariable name="NODE_ENV" value="$nodeEnv" />
      <environmentVariable name="PUBLIC_API_URL" value="$publicApiUrl" />
      <environmentVariable name="PORT" value="$FePort" />
    </environmentVariables>

    <security>
      <requestFiltering>
        <hiddenSegments>
          <add segment="node_modules" />
        </hiddenSegments>
      </requestFiltering>
    </security>

  </system.webServer>
</configuration>
"@

    Set-Content -Path $path -Value $content -Encoding UTF8
}

# ===========================
# MAIN
# ===========================
Ensure-Dir $FeDeployDir
Ensure-Dir $BeDeployDir

Ensure-IIS_Win10
Ensure-WebAdministration

# Validate IISNODE deps
if (-not (Test-NodeInstalled)) { Warn "Node.js not found in PATH. Install Node.js LTS." }
if (-not (Test-IisNodeInstalled)) { Warn "iisnode not detected. Install iisnode." }

$entryAbs = Join-Path $FeDeployDir $FeNodeEntry
if (-not (Test-Path -LiteralPath $entryAbs)) {
    Warn "FE Node entry NOT found: $entryAbs"
    Warn "You must build FE with adapter-node so build\\index.js exists (or set FeNodeEntry correctly)."
}

# Create FE site
Info "Setting up FE site (IISNODE)..."
Ensure-AppPool $FeAppPool
Ensure-Site -siteName $FeSiteName -appPool $FeAppPool -physicalPath $FeDeployDir -port $FePort -hostHeader $HostName

# Create BE site
Info "Setting up BE site (IIS)..."
Ensure-AppPool $BeAppPool
$beWebConfig = Join-Path $BeDeployDir "web.config"
if (-not (Test-Path -LiteralPath $beWebConfig)) {
    Warn "BE web.config not found in $BeDeployDir. IIS hosting may fail until you publish correctly."
}
Ensure-Site -siteName $BeSiteName -appPool $BeAppPool -physicalPath $BeDeployDir -port $BePort -hostHeader $HostName

# Enable ARR proxy if present
if ($EnableProxyFromFeToBe) {
    $hasRewrite = Test-UrlRewriteInstalled
    $hasArr = Test-ArrInstalled
    if (-not $hasRewrite) { Warn "URL Rewrite NOT detected. /api proxy rules may not work." }
    if (-not $hasArr) { Warn "ARR NOT detected. Reverse proxy won't work until installed." }
    if ($hasArr) {
        Info "ARR detected. Enabling proxy..."
        Set-WebConfigurationProperty -pspath 'MACHINE/WEBROOT/APPHOST' -filter "system.webServer/proxy" -name "enabled" -value "True" -ErrorAction SilentlyContinue
    }
}

# Write FE web.config for IISNODE
Info "Writing FE web.config for IISNODE..."
$feWebConfigPath = Join-Path $FeDeployDir "web.config"
Write-FeWebConfig_IisNode -path $feWebConfigPath -nodeEntryRel $FeNodeEntry -enableProxy $EnableProxyFromFeToBe `
    -bePort $BePort -nodeEnv $NodeEnv -publicApiUrl $PublicApiUrl

# Permissions
Info "Granting IIS_IUSRS read permissions..."
icacls $FeDeployDir /grant "IIS_IUSRS:(OI)(CI)R" /T | Out-Null
icacls $BeDeployDir /grant "IIS_IUSRS:(OI)(CI)R" /T | Out-Null

# Firewall
if ($ConfigureFirewall) {
    Info "Configuring firewall..."
    New-NetFirewallRule -DisplayName "AlumniCMS FE HTTP $FePort" -Direction Inbound -Protocol TCP -LocalPort $FePort -Action Allow -ErrorAction SilentlyContinue | Out-Null
    New-NetFirewallRule -DisplayName "AlumniCMS BE HTTP $BePort" -Direction Inbound -Protocol TCP -LocalPort $BePort -Action Allow -ErrorAction SilentlyContinue | Out-Null
}

# Restart IIS
Info "Restarting IIS..."
iisreset | Out-Null

Info "DONE."
Info ("FE: http://<your-ip>:{0}/ (IISNODE entry: {1})" -f $FePort, $FeNodeEntry)
Info ("BE: http://<your-ip>:{0}/" -f $BePort)
