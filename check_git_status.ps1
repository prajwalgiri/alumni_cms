# ===========================
# check-be-changes-and-run.ps1
# - Detect changes in BE folder
# - If changed -> run another ps1 script
# ===========================


[CmdletBinding(SupportsShouldProcess = $true)]
param(
    [string]$BePath,
    [string]$RunScriptPath,
    [string[]]$RunScriptArgs,
    [string]$StateFile,
    [string[]]$Include,
    [string[]]$ExcludeDirs
)
    
Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"
# ---------------------------
# Defaults (safe everywhere)
# ---------------------------
if ([string]::IsNullOrWhiteSpace($BePath)) { $BePath = ".\be" }
if ([string]::IsNullOrWhiteSpace($RunScriptPath)) { $RunScriptPath = ".\configure-iis.ps1" } #{ throw "RunScriptPath is required. Example: -RunScriptPath .\configure-iis-iisnode.ps1" }
if ($null -eq $RunScriptArgs -or $RunScriptArgs.Count -eq 0) { $RunScriptArgs = @("-Mode", "be") }
if ([string]::IsNullOrWhiteSpace($StateFile)) { $StateFile = ".\.deploy_state\be_last_state.txt" }
if ($null -eq $Include -or $Include.Count -eq 0) {
    $Include = @("*.cs", "*.csproj", "*.sln", "*.json", "*.xml", "*.config", "*.props", "*.targets", "*.sql", "*.ps1", "*.psm1", "Dockerfile", "*.yml", "*.yaml")
}
if ($null -eq $ExcludeDirs -or $ExcludeDirs.Count -eq 0) {
    $ExcludeDirs = @("bin", "obj", ".git", ".vs", "node_modules", "publish", "artifacts")
}

function Info($m) { Write-Host "[INFO] $m" -ForegroundColor Cyan }
function Warn($m) { Write-Host "[WARN] $m" -ForegroundColor Yellow }
function Ensure-Dir([string]$p) { if (-not (Test-Path -LiteralPath $p)) { New-Item -ItemType Directory -Force -Path $p | Out-Null } }

function Resolve-FullPath([string]$p) {
    if ([System.IO.Path]::IsPathRooted($p)) { return (Resolve-Path -LiteralPath $p).Path }
    return (Resolve-Path -LiteralPath (Join-Path (Get-Location) $p)).Path
}

function Has-Git {
    try { Get-Command git -ErrorAction Stop | Out-Null; return $true } catch { return $false }
}

function Is-GitRepo([string]$dir) {
    try {
        & git -C $dir rev-parse --is-inside-work-tree 2>$null | Out-Null
        return ($LASTEXITCODE -eq 0)
    }
    catch { return $false }
}

function Read-State([string]$file) {
    if (-not (Test-Path -LiteralPath $file)) { return $null }
    $v = (Get-Content -LiteralPath $file -Raw).Trim()
    if ([string]::IsNullOrWhiteSpace($v)) { return $null }
    return $v
}

function Write-State([string]$file, [string]$value) {
    $dir = Split-Path -Parent $file
    Ensure-Dir $dir
    Set-Content -LiteralPath $file -Value $value -Encoding UTF8
}

function Get-HeadCommit([string]$repoRoot) {
    $sha = & git -C $repoRoot rev-parse HEAD
    if ($LASTEXITCODE -ne 0) { throw "Failed to read HEAD commit from git." }
    return $sha.Trim()
}

function Get-ChangedFiles-SinceCommit([string]$repoRoot, [string]$fromCommit, [string]$pathWithinRepo) {
    # name-only diff from stored commit -> HEAD, limited to BE path
    $files = & git -C $repoRoot diff --name-only $fromCommit HEAD -- $pathWithinRepo
    if ($LASTEXITCODE -ne 0) { throw "git diff failed." }
    return @($files | Where-Object { -not [string]::IsNullOrWhiteSpace($_) })
}

function Get-UncommittedChanges([string]$repoRoot, [string]$pathWithinRepo) {
    # includes staged + unstaged changes under BE path
    $out = & git -C $repoRoot status --porcelain -- $pathWithinRepo
    if ($LASTEXITCODE -ne 0) { throw "git status failed." }
    return @($out | Where-Object { -not [string]::IsNullOrWhiteSpace($_) })
}

function Get-RepoRoot([string]$anyPathInRepo) {
    $root = & git -C $anyPathInRepo rev-parse --show-toplevel
    if ($LASTEXITCODE -ne 0) { throw "Failed to detect git repo root." }
    return $root.Trim()
}

function Compute-FolderHash([string]$root, [string[]]$include, [string[]]$excludeDirs) {
    $root = Resolve-FullPath $root

    $excludeSet = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::OrdinalIgnoreCase)
    foreach ($d in $excludeDirs) { [void]$excludeSet.Add($d) }

    $files = Get-ChildItem -LiteralPath $root -Recurse -File -Force | Where-Object {
        # exclude directories by name anywhere in path
        $rel = $_.FullName.Substring($root.Length).TrimStart('\', '/')
        foreach ($seg in ($rel -split '[\\/]+')) {
            if ($excludeSet.Contains($seg)) { return $false }
        }
        # include patterns
        foreach ($pat in $include) {
            if ($_.Name -like $pat) { return $true }
        }
        return $false
    } | Sort-Object FullName

    $sha256 = [System.Security.Cryptography.SHA256]::Create()
    try {
        foreach ($f in $files) {
            # mix path + content into a single deterministic hash
            $relPathBytes = [System.Text.Encoding]::UTF8.GetBytes($f.FullName.Substring($root.Length))
            [void]$sha256.TransformBlock($relPathBytes, 0, $relPathBytes.Length, $null, 0)

            $contentBytes = [System.IO.File]::ReadAllBytes($f.FullName)
            [void]$sha256.TransformBlock($contentBytes, 0, $contentBytes.Length, $null, 0)
        }
        [void]$sha256.TransformFinalBlock(@(), 0, 0)
        return ([BitConverter]::ToString($sha256.Hash) -replace '-', '').ToLowerInvariant()
    }
    finally {
        $sha256.Dispose()
    }
}

# ---------------------------
# MAIN
# ---------------------------
$beFull = Resolve-FullPath $BePath
if (-not (Test-Path -LiteralPath $beFull)) { throw "BE path not found: $beFull" }

$runScriptFull = Resolve-FullPath $RunScriptPath
if (-not (Test-Path -LiteralPath $runScriptFull)) { throw "Run script not found: $runScriptFull" }

$statePrev = Read-State $StateFile

$changed = $false
$reason = ""

if (Has-Git -and Is-GitRepo $beFull) {
    $repoRoot = Get-RepoRoot $beFull
    $beRel = Resolve-Path -LiteralPath $beFull | ForEach-Object {
        $_.Path.Substring($repoRoot.Length).TrimStart('\', '/')
    }

    Info "Using git-based change detection."
    $head = Get-HeadCommit $repoRoot

    # 1) If there are uncommitted changes under BE, treat as changed
    $uncommitted = Get-UncommittedChanges $repoRoot $beRel
    if ($uncommitted.Count -gt 0) {
        $changed = $true
        $reason = "Uncommitted changes detected under '$beRel'."
    }
    else {
        # 2) Otherwise, compare last saved commit -> current HEAD
        if ([string]::IsNullOrWhiteSpace($statePrev)) {
            $changed = $true
            $reason = "No previous state found; treating as changed (first run)."
        }
        elseif ($statePrev -ne $head) {
            $diff = Get-ChangedFiles-SinceCommit $repoRoot $statePrev $beRel
            if ($diff.Count -gt 0) {
                $changed = $true
                $reason = "Committed changes detected under '$beRel' since last state ($statePrev -> $head)."
            }
            else {
                $changed = $false
                $reason = "HEAD changed but no BE files changed."
            }
        }
        else {
            $changed = $false
            $reason = "No changes since last state (HEAD=$head)."
        }
    }

    Info $reason

    if ($changed) {
        
        Info "Running script..."
        Info "Running publish script..."
        & powershell.exe -ExecutionPolicy Bypass -File publish.ps1 -Mode be -VerboseLog;
        powershell.exe -ExecutionPolicy Bypass -File publish.ps1 -Mode be -VerboseLog;
        if ($LASTEXITCODE -ne 0) { throw "Publish script failed with exit code $LASTEXITCODE" }
            
        Info "Running configure-iis script..."
        & powershell.exe -ExecutionPolicy Bypass -File configure-iis.ps1 -Mode be
        if ($LASTEXITCODE -ne 0) { throw "Configure-iis script failed with exit code $LASTEXITCODE" }
        # Save new state as HEAD commit after successful run
        $newHead = Get-HeadCommit $repoRoot
        Write-State $StateFile $newHead
        Info "Saved state: $newHead"
        
    }
    else {
        Info "Skipping run; BE unchanged."
    }
}
else {
    Info "Git not available or not a git repo. Using content-hash fallback."

    $hash = Compute-FolderHash -root $beFull -include $Include -excludeDirs $ExcludeDirs
    if ([string]::IsNullOrWhiteSpace($statePrev)) {
        $changed = $true
        $reason = "No previous hash state; treating as changed (first run)."
    }
    elseif ($statePrev -ne $hash) {
        $changed = $true
        $reason = "BE content hash changed."
    }
    else {
        $changed = $false
        $reason = "BE unchanged (same hash)."
    }

    Info $reason

    if ($changed) {
       
        else {
            Info "Running publish script..."
            & powershell.exe -ExecutionPolicy Bypass -File publish.ps1 -Mode be -VerboseLog
            if ($LASTEXITCODE -ne 0) { throw "Publish script failed with exit code $LASTEXITCODE" }
            
            Info "Running configure-iis script..."
            & powershell.exe -ExecutionPolicy Bypass -File configure-iis.ps1 -Mode be -VerboseLog
            if ($LASTEXITCODE -ne 0) { throw "Configure-iis script failed with exit code $LASTEXITCODE" }

            Write-State $StateFile $hash
            Info "Saved hash state: $hash"
        }
    }
    else {
        Info "Skipping run; BE unchanged."
    }
}

exit 0
