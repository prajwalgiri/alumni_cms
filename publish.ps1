<#  Write-Log "---- BE: publish (local-iis) ----"
    #Write-Output "$DotnetCmd publish $BePath\Web.Api\Alumni.Web.Api.csproj /p:Configuration=Release /p:OutDir= $BeDeployDir" $BePath
    #Exec "$DotnetCmd publish $BePath\Web.Api\Alumni.Web.Api.csproj /p:Configuration=Release /p:OutDir= $BeDeployDir" $BePath
    Exec "dotnet publish $BePath\WebApi\Alumni.WebApi.csproj /p:OutDir=$BeDeployDir" 
#>

# ===========================
# publish.ps1 (FE adapter-iis + BE API)
# FE: SvelteKit adapter-iis -> IIS site folder (iisnode)
# BE: dotnet publish -> deploy folder + run exe
# ===========================

[CmdletBinding(SupportsShouldProcess = $true)]
param (
    # Mode: fe | be | all
    [ValidateSet("fe", "be", "all")]
    [string]$Mode = "all",
    # FE deps mode
    [switch]$Dev,         # DEV mode: copy node_modules (default = install prod-only deps in deploy dir)

    # Safety / ops
    [switch]$NoBuild,       # Skip build steps (FE and/or BE)
    [switch]$ForceKillPort, # allow killing processes holding BE port (otherwise only stop PID-file process)
    [switch]$VerboseLog     # extra verbose logs (independent from PowerShell -Verbose)
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

# -------- CONFIG --------
$RepoRoot = Split-Path -Parent $MyInvocation.MyCommand.Path

# FE
$FePath = Join-Path $RepoRoot "fe"
$FeDeployDir = "C:\deploy\alumni\alumni-fe"
$BuildFeInTemp = $false # avoids EPERM

# BE
$BePath = Join-Path $RepoRoot "be"
$BeProjectPath = Join-Path $BePath "WebApi\Alumni.WebApi.csproj"
$BeConfiguration = "Release"
$BeExeName = "Alumni.WebAPI.exe"
$BePort = 3002
$BeDeployDir = "C:\deploy\alumni\alumni-be"
$BePidFile = Join-Path $BeDeployDir "be.pid"

# Logging
$LogDir = "C:\deploy\alumni\logs"
$BeRunLog = Join-Path $LogDir "be-run.log"
$PublishLog = Join-Path $LogDir ("publish-" + (Get-Date -Format "yyyyMMdd") + ".log")



# Robocopy
$UseRobocopy = $true
$RobocopyFlags = "/MIR /NFL /NDL /NJH /NJS /NP /R:1 /W:1"
# -------- END CONFIG --------

# ===========================
# Helper functions (refactored)
# ===========================
function Resolve-Exe([string]$name, [string[]]$fallbacks = @()) {
    $c = Get-Command $name -ErrorAction SilentlyContinue
    if ($c -and $c.Source) { return $c.Source }

    foreach ($f in $fallbacks) {
        $c2 = Get-Command $f -ErrorAction SilentlyContinue
        if ($c2 -and $c2.Source) { return $c2.Source }
    }

    Fail "Tool not found in PATH: $name (tried: $($fallbacks -join ', ')). Fix PATH or install the tool."
}

# Tools
$BunCmd = "bun" #Resolve-Exe "bun" @("bun.cmd")
$DotnetCmd = "dotnet" #Resolve-Exe "dotnet" @("dotnet.exe")

function Ensure-Dir([string]$path) {
    if (-not $path) { return }
    if (-not (Test-Path -LiteralPath $path)) {
        New-Item -ItemType Directory -Force -Path $path | Out-Null
    }
}

function Write-Log([string]$msg) {
    Ensure-Dir (Split-Path -Parent $PublishLog)
    $line = "[{0}] {1}" -f (Get-Date -Format "yyyy-MM-dd HH:mm:ss"), $msg
    if ($VerboseLog) { Write-Output $line }
    $line | Tee-Object -FilePath $PublishLog -Append | Out-Null
}

function Fail([string]$msg) {
    Write-Log ("ERROR: {0}" -f $msg)
    throw $msg
}

function Format-Args([string[]]$args) {
    if (-not $args) { return "" }
    return ($args | ForEach-Object {
            if ($_ -match '\s|"' ) { '"' + ($_ -replace '"', '\"') + '"' } else { $_ }
        }) -join ' '
}


# Preferred runner: avoids cmd.exe where possible
<#
function Execute-FileCmd(
    [string]$file,
    [string[]]$arguments = @(),
    [string]$workdir = $null,
    [hashtable]$env = $null
) {
    $argLine = Format-Args $arguments

    $cwd = ""
    if ($workdir) { $cwd = $workdir }

    Write-Log ("RUN: {0} {1} (cwd={2})" -f $file, $argLine, $cwd)

    if ($PSCmdlet -and (-not $PSCmdlet.ShouldProcess("$file $argLine", "Execute"))) {
        return
    }

    $psi = New-Object System.Diagnostics.ProcessStartInfo
    $psi.FileName = $file
    $psi.Arguments = $argLine
    $psi.UseShellExecute = $false
    $psi.RedirectStandardOutput = $true
    $psi.RedirectStandardError = $true
    if ($workdir) { $psi.WorkingDirectory = $workdir }

    if ($env) {
        foreach ($k in $env.Keys) {
            $psi.EnvironmentVariables[$k] = [string]$env[$k]
        }
    }

    $p = New-Object System.Diagnostics.Process
    $p.StartInfo = $psi

    $null = $p.Start()
    $stdout = $p.StandardOutput.ReadToEnd()
    $stderr = $p.StandardError.ReadToEnd()
    $p.WaitForExit()

    if ($stdout) { $stdout.TrimEnd() -split "`r?`n" | ForEach-Object { Write-Log ("  " + $_) } }
    if ($stderr) { $stderr.TrimEnd() -split "`r?`n" | ForEach-Object { Write-Log ("  " + $_) } }

    if ($p.ExitCode -ne 0) {
        Fail ("Command failed (ExitCode={0}): {1} {2}" -f $p.ExitCode, $file, $argLine)
    }
}

#>


# Keep cmd runner ONLY for legacy compound commands (&&, redirection, etc.)
function Execute-Cmd([string]$cmd, [string]$workdir = $null) {

    $cwd = ""
    if ($workdir) { $cwd = $workdir }

    Write-Log ("RUN(CMD): {0} (cwd={1})" -f $cmd, $cwd)

    if ($PSCmdlet -and (-not $PSCmdlet.ShouldProcess($cmd, "Execute via cmd.exe"))) {
        return
    }

    if ($workdir -and $workdir -ne "") {
        $p = Start-Process -FilePath "cmd.exe" -ArgumentList "/c", $cmd -WorkingDirectory $workdir -Wait -PassThru -NoNewWindow
    }
    else {
        $p = Start-Process -FilePath "cmd.exe" -ArgumentList "/c", $cmd -Wait -PassThru -NoNewWindow
    }

    if ($p.ExitCode -ne 0) {
        Fail ("Command failed (ExitCode={0}): {1}" -f $p.ExitCode, $cmd)
    }
}



function Measure-Step([string]$name, [scriptblock]$block) {
    Write-Log ("-- START: {0}" -f $name)
    $sw = [System.Diagnostics.Stopwatch]::StartNew()
    try {
        & $block
        $sw.Stop()
        Write-Log ("-- DONE:  {0} ({1:n1}s)" -f $name, $sw.Elapsed.TotalSeconds)
    }
    catch {
        $sw.Stop()
        Write-Log ("-- FAIL:  {0} ({1:n1}s) :: {2}" -f $name, $sw.Elapsed.TotalSeconds, $_.Exception.Message)
        throw
    }
}

function Robocopy-Mirror([string]$src, [string]$dst, [string[]]$excludeDirs = @(), [string[]]$excludeFiles = @()) {
    Ensure-Dir $dst

    if (-not $UseRobocopy) {
        Write-Log ("Copy-Item fallback: {0} -> {1}" -f $src, $dst)
        if (-not $PSCmdlet.ShouldProcess("$dst", "Copy from $src")) { return }
        Copy-Item -Path (Join-Path $src "*") -Destination $dst -Recurse -Force
        return
    }

    $args = @($src, $dst) + ($RobocopyFlags -split '\s+')
    if ($excludeDirs -and $excludeDirs.Count -gt 0) { $args += "/XD"; $args += $excludeDirs }
    if ($excludeFiles -and $excludeFiles.Count -gt 0) { $args += "/XF"; $args += $excludeFiles }

    Write-Log ("RUN: robocopy {0}" -f (Format-Args $args))
    if (-not $PSCmdlet.ShouldProcess("$dst", "Robocopy mirror from $src")) { return }

    $p = Start-Process -FilePath "robocopy.exe" -ArgumentList $args -WorkingDirectory $RepoRoot -Wait -PassThru -NoNewWindow
    # Robocopy: 0-7 are success-ish; >7 is failure
    if ($p.ExitCode -gt 7) { Fail ("Robocopy failed (ExitCode={0})" -f $p.ExitCode) }
}

function Get-BunInstallCmd([string]$workdir, [bool]$prodOnly) {
    $lock = Join-Path $workdir "bun.lock"
    $hasLock = Test-Path -LiteralPath $lock

    if ($prodOnly) {
        if ($hasLock) { return @("install", "--prod", "--frozen-lockfile") }
        return @("install", "--prod", "--no-frozen-lockfile")
    }

    if ($hasLock) { return @("install", "--frozen-lockfile") }
    return @("install", "--no-frozen-lockfile")
}

function Stop-ByPidFile([string]$pidFile) {
    if (-not (Test-Path -LiteralPath $pidFile)) { return }
    $psid = (Get-Content $pidFile -ErrorAction SilentlyContinue | Select-Object -First 1)
    if ($psid) {
        try {
            $p = Get-Process -Id $psid -ErrorAction SilentlyContinue
            if ($p) { Write-Log ("Stopping PID from pidfile: {0} ({1})" -f $psid, $p.ProcessName) }
            if ($PSCmdlet.ShouldProcess("PID $psid", "Stop-Process")) {
                Stop-Process -Id $psid -Force -ErrorAction SilentlyContinue
            }
        }
        catch {}
    }
    Remove-Item $pidFile -Force -ErrorAction SilentlyContinue
}

function Ensure-Port-Free([int]$port, [switch]$ForceKillPort) {
    $conns = Get-NetTCPConnection -LocalPort $port -ErrorAction SilentlyContinue
    if (-not $conns) { return }

    $pids = $conns | Select-Object -ExpandProperty OwningProcess -Unique
    foreach ($psid in $pids) {
        $p = Get-Process -Id $psid -ErrorAction SilentlyContinue
        $name = if ($p) { $p.ProcessName } else { "unknown" }
        Write-Log ("Port {0} is in use by PID={1} Name={2}" -f $port, $psid, $name)

        if (-not $ForceKillPort) {
            Write-Log "Skipping kill (use -ForceKillPort to allow killing foreign processes)."
            continue
        }

        if ($PSCmdlet.ShouldProcess("PID $psid ($name)", "Stop-Process (free port)")) {
            try { Stop-Process -Id $psid -Force -ErrorAction SilentlyContinue } catch {}
        }
    }
}

# ---------- FE: adapter-iis config patch ----------
function Get-NodeExePath {
    $cmd = Get-Command node -ErrorAction SilentlyContinue
    if (-not $cmd -or -not $cmd.Source) {
        Fail "Node.js not found in PATH. Install Node.js or ensure node.exe is available."
    }
    return $cmd.Source
}

function Test-DevDependencyPresent([string]$workdir, [string]$pkgName) {
    $pkgJson = Join-Path $workdir "package.json"
    if (-not (Test-Path -LiteralPath $pkgJson)) { return $false }

    $json = Get-Content -LiteralPath $pkgJson -Raw -Encoding UTF8 | ConvertFrom-Json

    $inDeps = $false
    if ($json.dependencies -and $json.dependencies.PSObject.Properties.Name -contains $pkgName) { $inDeps = $true }
    if ($json.devDependencies -and $json.devDependencies.PSObject.Properties.Name -contains $pkgName) { $inDeps = $true }

    if (-not $inDeps) { return $false }

    # Optional physical check (handles workspace/hoist differences gracefully)
    $nmPath = Join-Path $workdir "node_modules\$pkgName"
    $nmScoped = Join-Path $workdir "node_modules\$($pkgName.Replace('/','\'))"
    if ((Test-Path -LiteralPath $nmPath) -or (Test-Path -LiteralPath $nmScoped)) { return $true }

    # Declared but node_modules not present (install may not have run yet)
    return $true
}



function Ensure-AdapterIis-NodeCommandLine {
    param([Parameter(Mandatory = $true)][string]$FeRoot)

    $cfgPath = Join-Path $FeRoot "svelte.config.js"
    if (-not (Test-Path -LiteralPath $cfgPath)) {
        Fail ("svelte.config.js not found at: {0}" -f $cfgPath)
    }

    # Bun-friendly check: verify package is declared in package.json (deps or devDeps)
    if (-not (Test-DevDependencyPresent -workdir $FeRoot -pkgName "sveltekit-adapter-iis")) {
        Fail "Missing package: sveltekit-adapter-iis. Add it to devDependencies (bun add -d sveltekit-adapter-iis) then rerun."
    }

    $text = Get-Content -LiteralPath $cfgPath -Raw -Encoding UTF8

    # import <ALIAS> from 'sveltekit-adapter-iis';
    $mImport = [regex]::Match(
        $text,
        "import\s+([A-Za-z_\$][A-Za-z0-9_\$]*)\s+from\s+['""]sveltekit-adapter-iis['""]\s*;",
        [System.Text.RegularExpressions.RegexOptions]::Singleline
    )
    if (-not $mImport.Success) {
        Fail "svelte.config.js does not import from 'sveltekit-adapter-iis'. Configure adapter-iis first."
    }
    $adapterAlias = $mImport.Groups[1].Value

    $adapterCallPattern = "adapter\s*:\s*" + [regex]::Escape($adapterAlias) + "\s*\(\s*\{"
    if ($text -notmatch $adapterCallPattern) {
        Fail ("svelte.config.js imports adapter-iis as '{0}' but does not use it as adapter: {0}({{ ... }})." -f $adapterAlias)
    }

    # Resolve node.exe absolute path for IISNODE (you can change to 'node' if preferred)
    $cmd = Get-Command node -ErrorAction SilentlyContinue
    if (-not $cmd -or -not $cmd.Source) {
        Fail "Node.js not found in PATH. Install Node.js or ensure node.exe is available."
    }
    $nodeExe = $cmd.Source
    $nodeEsc = $nodeExe -replace "\\", "\\\\"

    # Locate the adapter options object braces
    $match = [regex]::Match($text, $adapterCallPattern)
    if (-not $match.Success) { Fail "Internal error: adapter call match failed." }
    $idx = $match.Index
    $openBraceIdx = $text.IndexOf("{", $idx)
    if ($openBraceIdx -lt 0) { Fail "Could not locate adapter options object '{'." }

    $i = $openBraceIdx
    $depth = 0
    $closeBraceIdx = -1
    while ($i -lt $text.Length) {
        $ch = $text[$i]
        if ($ch -eq "{") { $depth++ }
        elseif ($ch -eq "}") {
            $depth--
            if ($depth -eq 0) { $closeBraceIdx = $i; break }
        }
        $i++
    }
    if ($closeBraceIdx -lt 0) { Fail "Could not parse adapter options object (brace matching failed)." }

    $before = $text.Substring(0, $openBraceIdx + 1)
    $obj = $text.Substring($openBraceIdx + 1, $closeBraceIdx - $openBraceIdx - 1)
    $after = $text.Substring($closeBraceIdx)

    $changed = $false

    if ($obj -notmatch "\biisNodeOptions\s*:") {
        $injection = "`r`n`t`t`tiisNodeOptions: {`r`n`t`t`t\tnodeProcessCommandLine: '$nodeEsc',`r`n`t`t`t},"
        $obj = $injection + $obj
        $changed = $true
    }
    elseif ($obj -notmatch "iisNodeOptions\s*:\s*\{[\s\S]*?\bnodeProcessCommandLine\s*:") {
        $obj2 = [regex]::Replace(
            $obj,
            "(iisNodeOptions\s*:\s*\{)",
            "`$1`r`n`t`t`t\tnodeProcessCommandLine: '$nodeEsc',",
            1,
            [System.Text.RegularExpressions.RegexOptions]::Singleline
        )
        if ($obj2 -ne $obj) { $obj = $obj2; $changed = $true }
    }
    else {
        $obj2 = [regex]::Replace(
            $obj,
            "(nodeProcessCommandLine\s*:\s*['""])([^'""]+)(['""])",
            "`$1$nodeEsc`$3",
            1
        )
        if ($obj2 -ne $obj) { $obj = $obj2; $changed = $true }
    }

    if ($changed) {
        $newText = $before + $obj + $after
        if ($PSCmdlet.ShouldProcess($cfgPath, "Update nodeProcessCommandLine")) {
            Set-Content -LiteralPath $cfgPath -Value $newText -Encoding UTF8
        }
        Write-Log ("Updated svelte.config.js: adapter '{0}' iisNodeOptions.nodeProcessCommandLine = {1}" -f $adapterAlias, $nodeExe)
    }
    else {
        Write-Log ("svelte.config.js already has correct nodeProcessCommandLine: {0}" -f $nodeExe)
    }
}


# ===========================
# Publish plan resolution (quality fix)
# ===========================
$ShouldPublishFe = $false
$ShouldPublishBe = $false

switch ($Mode) {
    "fe" { $ShouldPublishFe = $true }
    "be" { $ShouldPublishBe = $true }
    "all" {
        $ShouldPublishFe = $true
        $ShouldPublishBe = $true
    }
}

if ($NoBuild) {
    $ShouldPublishFe = $false
    $ShouldPublishBe = $false
}

$ShouldCopyNodeModules = $Dev

Write-Log ("Plan: Mode={0}, PublishFE={1}, PublishBE={2}, DevCopyNodeModules={3}" `
        -f $Mode, $ShouldPublishFe, $ShouldPublishBe, $ShouldCopyNodeModules)


# ===========================
# MAIN
# ===========================
Ensure-Dir $LogDir
Ensure-Dir $FeDeployDir
Ensure-Dir $BeDeployDir

Write-Log "==== Publish started ===="
Write-Log ("RepoRoot: {0}" -f $RepoRoot)

try {
    # ---------------------------
    # FE BUILD + DEPLOY
    # ---------------------------
    if ($ShouldPublishFe) {
        Measure-Step "FE publish" {
            if (-not (Test-Path -LiteralPath $FePath)) { Fail ("Frontend path not found: {0}" -f $FePath) }

            $feBuildRoot = $FePath
            $tempRoot = $null

            Write-Log ("FE source: {0}" -f $FePath)
            Write-Log ("FE deploy:  {0}" -f $FeDeployDir)
            Write-Log ("FE mode:    {0}" -f ($(if ($ShouldCopyNodeModules) { "DEV(copy node_modules)" } else { "PROD(install prod deps)" })))

            if ($BuildFeInTemp) {
                $tempRoot = Join-Path $env:TEMP ("fe_build_" + [guid]::NewGuid().ToString("N"))
                Ensure-Dir $tempRoot
                $feBuildRoot = $tempRoot
                Write-Log ("FE temp root: {0}" -f $tempRoot)

                Measure-Step "FE copy to temp" {
                    Robocopy-Mirror $FePath $feBuildRoot @("node_modules", ".svelte-kit", "build", ".git") @()
                }
            }

            # Measure-Step "FE tool versions" {
            #     Execute-FileCmd "$BunCmd -v" $feBuildRoot
            #     Execute-FileCmd "node.exe -v" $feBuildRoot
            # }

            Measure-Step "FE install (dev deps)" {
                $installArgs = Get-BunInstallCmd -workdir $feBuildRoot -prodOnly:$false
                Write-Log ("FE install args: bun {0}" -f (Format-Args $installArgs))
                Execute-Cmd "$BunCmd install --production" $feBuildRoot
            }

            Measure-Step "FE patch svelte.config.js (nodeProcessCommandLine)" {
                Ensure-AdapterIis-NodeCommandLine -FeRoot $feBuildRoot
            }

            Measure-Step "FE build" {
                Execute-Cmd "$BunCmd run build" $feBuildRoot
            }

            $feOutRoot = Join-Path $feBuildRoot ".svelte-kit\adapter-iis"
            $feWebConfig = Join-Path $feOutRoot "web.config"
            $entryAbs = Join-Path $feOutRoot "node-server.cjs"

            if (-not (Test-Path -LiteralPath $feWebConfig)) { Fail ("FE output missing web.config: {0}" -f $feWebConfig) }
            if (-not (Test-Path -LiteralPath $entryAbs)) { Fail ("FE output missing entry node-server.cjs: {0}" -f $entryAbs) }

            Measure-Step "FE deploy mirror output" {
                Robocopy-Mirror $feOutRoot $FeDeployDir @() @()
            }

            if ($ShouldCopyNodeModules) {
                Measure-Step "FE deps copy node_modules" {
                    $srcNm = Join-Path $feBuildRoot "node_modules"
                    if (-not (Test-Path -LiteralPath $srcNm)) { Fail ("node_modules not found at: {0}" -f $srcNm) }

                    $dstNm = Join-Path $FeDeployDir "node_modules"
                    if (Test-Path -LiteralPath $dstNm) {
                        Write-Log "FE deps: deleting existing deploy node_modules..."
                        if ($PSCmdlet.ShouldProcess($dstNm, "Remove node_modules")) {
                            try { Remove-Item -LiteralPath $dstNm -Recurse -Force -ErrorAction Stop } catch { Write-Log ("WARN: " + $_.Exception.Message) }
                        }
                    }

                    Robocopy-Mirror $srcNm $dstNm @() @()
                }
            }
            else {
                Measure-Step "FE deps install prod-only" {
                    $nm = Join-Path $FeDeployDir "node_modules"
                    if (Test-Path -LiteralPath $nm) {
                        Write-Log "FE deps: deleting existing deploy node_modules..."
                        if ($PSCmdlet.ShouldProcess($nm, "Remove node_modules")) {
                            try { Remove-Item -LiteralPath $nm -Recurse -Force -ErrorAction Stop } catch { Write-Log ("WARN: " + $_.Exception.Message) }
                        }
                    }

                    $deployInstallArgs = Get-BunInstallCmd -workdir $FeDeployDir -prodOnly:$true
                    Write-Log ("FE deploy install args: bun {0}" -f (Format-Args $deployInstallArgs))
                    Execute-Cmd "$BunCmd install --production" $FeDeployDir
                }
            }

            if ($tempRoot -and (Test-Path -LiteralPath $tempRoot)) {
                Measure-Step "FE cleanup temp" {
                    if ($PSCmdlet.ShouldProcess($tempRoot, "Remove temp FE build")) {
                        Remove-Item -LiteralPath $tempRoot -Recurse -Force -ErrorAction SilentlyContinue
                    }
                }
            }
        }
    }
    else {
        Write-Log "==== FE: skipped ===="
    }

    # ---------------------------
    # BE BUILD + DEPLOY
    # ---------------------------
    if ($ShouldPublishBe) {
        Measure-Step "BE publish" {
            if (-not (Test-Path -LiteralPath $BeProjectPath)) { Fail ("Backend project not found: {0}" -f $BeProjectPath) }

            Measure-Step "BE tool version" {
                Execute-Cmd "$DotnetCmd --version" $BePath
            }

            $bePublishTemp = Join-Path $env:TEMP ("be_publish_" + [guid]::NewGuid().ToString("N"))
            Ensure-Dir $bePublishTemp
            Write-Log ("BE publish temp: {0}" -f $bePublishTemp)

            try {
                Measure-Step "BE dotnet publish" {
                    Execute-Cmd "$DotnetCmd publish $BeProjectPath -c $BeConfiguration -o $bePublishTemp" $BePath
                }

                Measure-Step "BE stop old + free port" {
                    Stop-ByPidFile $BePidFile
                    Ensure-Port-Free -port $BePort -ForceKillPort:$ForceKillPort
                }

                Measure-Step "BE deploy mirror output" {
                    Robocopy-Mirror $bePublishTemp $BeDeployDir @() @()
                }

                Measure-Step "BE start process" {
                    $beExe = Join-Path $BeDeployDir $BeExeName
                    if (-not (Test-Path -LiteralPath $beExe)) {
                        $found = @((Get-ChildItem -LiteralPath $BeDeployDir -Filter "*.exe" -ErrorAction SilentlyContinue) | Select-Object -First 1)
                        if ($found.Count -eq 0) { Fail "Backend exe not found. Set `$BeExeName correctly." }
                        $beExe = $found[0].FullName
                        Write-Log ("BE exe auto-detected: {0}" -f $beExe)
                    }

                    Ensure-Dir (Split-Path -Parent $BeRunLog)

                    # Use cmd only because of output redirection to file
                    $cmd = "/c set ASPNETCORE_URLS=http://*:$BePort && `"$beExe`" >> `"$BeRunLog`" 2>&1"
                    Write-Log ("BE run log: {0}" -f $BeRunLog)
                    if ($PSCmdlet.ShouldProcess($beExe, "Start BE process")) {
                        $proc = Start-Process -FilePath "cmd.exe" -ArgumentList $cmd -PassThru -WindowStyle Hidden
                        $proc.Id | Out-File -FilePath $BePidFile -Force
                        Write-Log ("BE started PID={0} port={1}" -f $proc.Id, $BePort)
                    }
                }
            }
            finally {
                if (Test-Path -LiteralPath $bePublishTemp) {
                    Measure-Step "BE cleanup temp" {
                        if ($PSCmdlet.ShouldProcess($bePublishTemp, "Remove temp BE publish")) {
                            Remove-Item -LiteralPath $bePublishTemp -Recurse -Force -ErrorAction SilentlyContinue
                        }
                    }
                }
            }
        }
    }
    else {
        Write-Log "==== BE: skipped ===="
    }

    Write-Log "==== Publish completed successfully ===="
    exit 0
}
catch {
    Write-Log ("==== Publish FAILED ====")
    Write-Log ("Reason: {0}" -f $_.Exception.Message)
    exit 1
}
