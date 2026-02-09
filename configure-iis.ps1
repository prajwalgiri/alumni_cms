# ===========================
# configure-iis-iisnode.ps1 (Windows 10)
# FE: SvelteKit SSR via IISNODE on port 3000
# BE: ASP.NET Core in IIS on port 3002
# ===========================
[CmdletBinding(SupportsShouldProcess = $true)]
param(
    # Mode: fe | be | all
    [ValidateSet("fe", "be", "all")]
    [string]$Mode = "all"
)

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
    $psi.Arguments = "-ExecutionPolicy Bypass -File `"$PSCommandPath`" -Mode $Mode"
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
$HostName = ""                     # empty = IP access
$FeNodeEntry = "build/index.js"        # adapter-node output

# Runtime env passed to Node
$NodeEnv = "production"
$PublicApiUrl = "http://localhost:3002"

# BE (ASP.NET Core in IIS)
$BeSiteName = "AlumniCMS_API"
$BeAppPool = "AlumniCMS_API_AppPool"
$BeDeployDir = "C:\deploy\alumni\alumni-be"
$BePort = 3002

# Proxy /api -> BE
$EnableProxyFromFeToBe = $true

# Firewall
$ConfigureFirewall = $true
# ------------------------------------

$DoFe = ($Mode -eq "fe" -or $Mode -eq "all")
$DoBe = ($Mode -eq "be" -or $Mode -eq "all")

# ---------------------------
# Helpers
# ---------------------------
function Read-HostWithTimeout {
    param(
        [string]$Prompt,
        [int]$TimeoutSeconds = 5
    )

    Write-Host "$Prompt (auto-continue in $TimeoutSeconds seconds...)"

    $end = (Get-Date).AddSeconds($TimeoutSeconds)
    while ((Get-Date) -lt $end) {
        if ([Console]::KeyAvailable) {
            [Console]::ReadKey($true) | Out-Null
            return
        }
        Start-Sleep -Milliseconds 200
    }
}

function Ensure-Dir([string]$path) {
    if (-not (Test-Path -LiteralPath $path)) {
        New-Item -ItemType Directory -Force -Path $path | Out-Null
    }
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
        if ($state -and $state.State -ne "Enabled") {
            Enable-WindowsOptionalFeature -Online -FeatureName $f -All -NoRestart | Out-Null
        }
    }
}

function Ensure-WebAdministration {
    Import-Module WebAdministration -ErrorAction Stop
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
    $binding = "*:" + $port + ":" + $hostHeader


    if (-not (Test-Path "IIS:\Sites\$siteName")) {
        New-Item "IIS:\Sites\$siteName" -bindings @{ protocol = "http"; bindingInformation = $binding } -physicalPath $physicalPath | Out-Null
    }
    else {
        Set-ItemProperty "IIS:\Sites\$siteName" -Name physicalPath -Value $physicalPath
        if (-not (Get-WebBinding -Name $siteName -Port $port -ErrorAction SilentlyContinue)) {
            New-WebBinding -Name $siteName -Protocol http -Port $port -HostHeader $hostHeader | Out-Null
        }
    }
    Set-ItemProperty "IIS:\Sites\$siteName" -Name applicationPool -Value $appPool
    Start-WebSite $siteName | Out-Null
}

function Test-NodeInstalled {
    try { Get-Command node -ErrorAction Stop | Out-Null; $true } catch { $false }
}

function Test-IisNodeInstalled {
    Test-Path "$env:windir\System32\inetsrv\iisnode.dll"
}

function Write-FeWebConfig_IisNode {
    param(
        [string]$path,
        [string]$nodeEntryRel,
        [bool]$enableProxy,
        [int]$bePort,
        [string]$nodeEnv,
        [string]$publicApiUrl
    )

    $proxyRule = ""
    if ($enableProxy) {
        $proxyRule = @"
        <rule name="ReverseProxy_API" stopProcessing="true">
          <match url="^api/(.*)" />
          <action type="Rewrite" url="http://localhost:$bePort/api/{R:1}" />
        </rule>
"@
    }

    @"
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="NODE_ENV" value="$nodeEnv" />
    <add key="PUBLIC_API_URL" value="$publicApiUrl" />
    <add key="PORT" value="$FePort" />
  </appSettings>

  <system.webServer>
    <handlers>
      <add name="iisnode" path="$nodeEntryRel" verb="*" modules="iisnode" />
    </handlers>

    <rewrite>
      <rules>
$proxyRule
        <rule name="NodeApp" stopProcessing="true">
          <match url=".*" />
          <conditions>
            <add input="{REQUEST_URI}" pattern="^/api" negate="true" />
          </conditions>
          <action type="Rewrite" url="$nodeEntryRel" />
        </rule>
      </rules>
    </rewrite>

    <iisnode node_env="$nodeEnv" loggingEnabled="true" />
  </system.webServer>
</configuration>
"@ | Set-Content -Path $path -Encoding UTF8
}

# ===========================
# MAIN
# ===========================
Ensure-IIS_Win10
Ensure-WebAdministration

if ($DoFe) {
    if (-not (Test-NodeInstalled)) { Warn "Node.js not found in PATH." }
    if (-not (Test-IisNodeInstalled)) { Warn "iisnode not detected." }

    Info "Configuring FE..."
    Ensure-AppPool $FeAppPool
    Ensure-Site $FeSiteName $FeAppPool $FeDeployDir $FePort $HostName

    Write-FeWebConfig_IisNode `
        -path (Join-Path $FeDeployDir "web.config") `
        -nodeEntryRel $FeNodeEntry `
        -enableProxy $EnableProxyFromFeToBe `
        -bePort $BePort `
        -nodeEnv $NodeEnv `
        -publicApiUrl $PublicApiUrl

    icacls $FeDeployDir /grant "IIS_IUSRS:(OI)(CI)R" /T | Out-Null
}

if ($DoBe) {
    Info "Configuring BE..."
    Ensure-AppPool $BeAppPool
    Ensure-Site $BeSiteName $BeAppPool $BeDeployDir $BePort $HostName
    icacls $BeDeployDir /grant "IIS_IUSRS:(OI)(CI)R" /T | Out-Null
}

if ($ConfigureFirewall) {
    if ($DoFe) { New-NetFirewallRule -DisplayName "AlumniCMS FE $FePort" -Direction Inbound -Protocol TCP -LocalPort $FePort -Action Allow -ErrorAction SilentlyContinue | Out-Null }
    if ($DoBe) { New-NetFirewallRule -DisplayName "AlumniCMS BE $BePort" -Direction Inbound -Protocol TCP -LocalPort $BePort -Action Allow -ErrorAction SilentlyContinue | Out-Null }
}

Info "Restarting IIS..."
iisreset | Out-Null

Info "DONE."
if ($DoFe) { Info "FE: http://<your-ip>:$FePort/" }
if ($DoBe) { Info "BE: http://<your-ip>:$BePort/" }

Read-HostWithTimeout "Press Enter to exit..."
exit 0
