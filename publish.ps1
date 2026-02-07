# ===========================
# Publish Script (FE static + BE API)
# FE: SvelteKit adapter-static -> IIS static files
# BE: runs on port 3002 (process)
# ===========================

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

# -------- CONFIG (edit these) --------

$RepoRoot = Split-Path -Parent $MyInvocation.MyCommand.Path

# Frontend (SvelteKit static)
$FePath = Join-Path $RepoRoot "fe"
$FeInstallCommand = "pnpm install --frozen-lockfile"
$FeBuildCommand = "pnpm build"

# Where IIS serves the frontend static files from:
# Create an IIS Site/Virtual Dir pointing here.
$FeDeployDir = "C:\deploy\alumni\alumni-fe"

# Backend
$BePath = Join-Path $RepoRoot "be"
$BePublishCommand = "dotnet publish -c Release -o publish"   # change if Rust etc.
$BeExeName = "Backend.exe"                            # <-- CHANGE to your exe name
$BePort = 3002
$BeDeployDir = "C:\deploy\alumni\alumni-be"
$BePidFile = Join-Path $BeDeployDir "be.pid"

# Logging
$LogDir = "C:\deploy\alumni\logs"
$BeRunLog = Join-Path $LogDir "be-run.log"
$PublishLog = Join-Path $LogDir ("publish-" + (Get-Date -Format "yyyyMMdd") + ".log")

# Tools (set full paths if Task Scheduler PATH is limited)
$PnpmCmd = "pnpm"
$DotnetCmd = "dotnet"

# Safety
$FailOnGitDirty = $false
$UseRobocopy = $true
$RobocopyFlags = "/MIR /NFL /NDL /NJH /NJS /NP /R:1 /W:1"

# Build FE in temp workspace to avoid EPERM locks
$BuildFeInTemp = $true

# -------- END CONFIG --------


# ===========================
# Helpers
# ===========================

function Ensure-Dir([string]$path) {
    if (-not (Test-Path $path)) {
        New-Item -ItemType Directory -Force -Path $path | Out-Null
    }
}

function Write-Log([string]$msg) {
    $logParent = Split-Path -Parent $PublishLog
    Ensure-Dir $logParent

    $line = "[{0}] {1}" -f (Get-Date -Format "yyyy-MM-dd HH:mm:ss"), $msg
    $line | Tee-Object -FilePath $PublishLog -Append | Out-Null
}

function Fail([string]$msg) {
    Write-Log ("ERROR: {0}" -f $msg)
    exit 1
}

function Exec([string]$cmd, [string]$workdir) {
    Write-Log ("RUN: {0} (cwd={1})" -f $cmd, $workdir)
    $p = Start-Process -FilePath "cmd.exe" -ArgumentList "/c", $cmd -WorkingDirectory $workdir -Wait -PassThru -NoNewWindow
    if ($p.ExitCode -ne 0) { Fail ("Command failed (ExitCode={0}): {1}" -f $p.ExitCode, $cmd) }
}

function Ensure-Port-Free([int]$port) {
    $conns = Get-NetTCPConnection -LocalPort $port -ErrorAction SilentlyContinue
    if ($conns) {
        $pids = $conns | Select-Object -ExpandProperty OwningProcess -Unique
        foreach ($psid in $pids) {
            try {
                $proc = Get-Process -Id $psid -ErrorAction Stop
                Write-Log ("Port {0} is in use by PID={1} ({2}). Stopping it..." -f $port, $psid, $proc.ProcessName)
                Stop-Process -Id $psid -Force
            }
            catch {
                Write-Log ("Could not stop PID={0} for port {1}: {2}" -f $psid, $port, $_.Exception.Message)
            }
        }
    }
}

function Stop-ByPidFile([string]$pidFile, [string]$label) {
    if (Test-Path $pidFile) {
        $pid = Get-Content $pidFile -ErrorAction SilentlyContinue
        if ($pid) {
            try {
                Write-Log ("Stopping {0} (PID={1}) from pid file..." -f $label, $pid)
                Stop-Process -Id $pid -Force -ErrorAction Stop
            }
            catch {
                Write-Log ("Stop {0} by PID failed (maybe already stopped): {1}" -f $label, $_.Exception.Message)
            }
        }
        Remove-Item $pidFile -Force -ErrorAction SilentlyContinue
    }
}

function Copy-Dir([string]$src, [string]$dst) {
    Ensure-Dir $dst

    if ($UseRobocopy) {
        $cmd = "robocopy `"$src`" `"$dst`" $RobocopyFlags"
        Write-Log ("RUN: {0}" -f $cmd)
        $p = Start-Process -FilePath "cmd.exe" -ArgumentList "/c", $cmd -WorkingDirectory $RepoRoot -Wait -PassThru -NoNewWindow
        if ($p.ExitCode -gt 7) { Fail ("Robocopy failed (ExitCode={0})" -f $p.ExitCode) }
    }
    else {
        Copy-Item -Path (Join-Path $src "*") -Destination $dst -Recurse -Force
    }
}

function Git-Check() {
    if (-not (Get-Command git -ErrorAction SilentlyContinue)) {
        Write-Log "git not found; skipping git checks."
        return
    }

    Exec "git rev-parse --is-inside-work-tree" $RepoRoot

    if ($FailOnGitDirty) {
        $status = (cmd /c "git status --porcelain" 2>$null)
        if ($status) { Fail "Repo has uncommitted changes. Commit/stash before publishing (or set `$FailOnGitDirty = `$false)." }
    }

    $head = (cmd /c "git rev-parse --short HEAD" 2>$null)
    if ($head) { Write-Log ("Git HEAD: {0}" -f $head) }
}

function Robocopy-Exclude([string]$src, [string]$dst, [string[]]$excludeDirs) {
    Ensure-Dir $dst
    $args = @(
        "`"$src`"",
        "`"$dst`"",
        "/E", "/NFL", "/NDL", "/NJH", "/NJS", "/NP", "/R:1", "/W:1"
    )

    if ($excludeDirs -and $excludeDirs.Count -gt 0) {
        $args += "/XD"
        $args += $excludeDirs
    }

    Write-Log ("RUN: robocopy {0}" -f ($args -join " "))
    $p = Start-Process -FilePath "robocopy" -ArgumentList $args -Wait -PassThru -NoNewWindow
    if ($p.ExitCode -gt 7) { Fail ("Robocopy failed (ExitCode={0})" -f $p.ExitCode) }
}

# ===========================
# Main
# ===========================

Ensure-Dir $LogDir
Ensure-Dir $FeDeployDir
Ensure-Dir $BeDeployDir

Write-Log "==== Publish started ===="
Write-Log ("RepoRoot: {0}" -f $RepoRoot)

Git-Check

# -------- FE BUILD + DEPLOY (STATIC) --------
if (-not (Test-Path $FePath)) { Fail ("Frontend path not found: {0}" -f $FePath) }

Write-Log "---- Frontend: build ----"

if ($BuildFeInTemp) {
    # Copy FE source to temp to avoid EPERM file locks in repo
    $feBuildRoot = Join-Path $env:TEMP ("fe_build_" + [guid]::NewGuid().ToString("N"))
    Ensure-Dir $feBuildRoot

    # Copy everything except node_modules, build output, svelte-kit cache, git
    Robocopy-Exclude $FePath $feBuildRoot @("node_modules", ".svelte-kit", "build", ".git")

    Exec "$PnpmCmd -v" $feBuildRoot
    Exec "set CI=true && $PnpmCmd install --frozen-lockfile" $feBuildRoot
    Exec "set CI=true && $PnpmCmd build" $feBuildRoot

    # Deploy static build folder to IIS directory
    Write-Log "---- Frontend: deploy static files to IIS directory ----"
    Copy-Dir (Join-Path $feBuildRoot "build") $FeDeployDir

    Remove-Item $feBuildRoot -Recurse -Force -ErrorAction SilentlyContinue
}
else {
    # Build in-place (less reliable on Windows if something locks node_modules)
    Exec "$PnpmCmd -v" $FePath
    Exec $FeInstallCommand $FePath
    Exec $FeBuildCommand $FePath

    Write-Log "---- Frontend: deploy static files to IIS directory ----"
    Copy-Dir (Join-Path $FePath "build") $FeDeployDir
}

Write-Log "FE deployed to: $FeDeployDir"

# -------- BE BUILD + DEPLOY --------
if (-not (Test-Path $BePath)) { Fail ("Backend path not found: {0}" -f $BePath) }

Write-Log "---- Backend: publish ----"
Exec "$DotnetCmd --version" $BePath
Exec $BePublishCommand $BePath

Write-Log "---- Backend: deploy ----"
Stop-ByPidFile $BePidFile "BE"
Ensure-Port-Free $BePort

Copy-Dir (Join-Path $BePath "publish") $BeDeployDir

Write-Log "---- Backend: start ----"
$beExe = Join-Path $BeDeployDir $BeExeName
if (-not (Test-Path $beExe)) {
    $found = Get-ChildItem $BeDeployDir -Filter "*.exe" | Select-Object -First 1
    if (-not $found) { Fail "Backend exe not found. Set `$BeExeName correctly or ensure publish output includes an .exe." }
    $beExe = $found.FullName
    Write-Log ("BE exe auto-detected: {0}" -f $beExe)
}

# Set URL binding env for .NET (change/remove if Rust)
$beArgs = "/c set ASPNETCORE_URLS=http://*:$BePort && `"$beExe`" >> `"$BeRunLog`" 2>&1"
$beProc = Start-Process -FilePath "cmd.exe" -ArgumentList $beArgs -PassThru -WindowStyle Hidden
$beProc.Id | Out-File -FilePath $BePidFile -Force
Write-Log ("BE started. PID={0} Port={1}" -f $beProc.Id, $BePort)

Write-Log "==== Publish finished successfully ===="
exit 0
