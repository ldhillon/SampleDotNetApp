param (
    [string]$scpPath = "C:\Windows\System32\OpenSSH\scp.exe",
    [string]$sourcePath,
    [string]$destPath,
    [string]$sshKeyPath
)

Write-Output "SCP Path: $scpPath"
Write-Output "Source Path: $sourcePath"
Write-Output "Destination Path: $destPath"
Write-Output "SSH Key Path: $sshKeyPath"

# Check if SSH key file exists
if (-Not (Test-Path -Path $sshKeyPath)) {
    Write-Error "SSH key not found at path: $sshKeyPath"
    exit 1
}

# Test SSH connection
Write-Output "Testing SSH connection..."
try {
    & "C:\Windows\System32\OpenSSH\ssh.exe" -i $sshKeyPath admin@192.168.0.57 "echo SSH connection test"
    if ($LASTEXITCODE -ne 0) {
        throw "SSH connection test failed with exit code $LASTEXITCODE"
    }
    Write-Output "SSH connection test successful."
}
catch {
    Write-Error "An error occurred during SSH connection test: $_"
    exit 1
}

# Perform SCP transfer
Write-Output "Starting SCP transfer..."
try {
    & $scpPath -vvv -i $sshKeyPath $sourcePath $destPath
    if ($LASTEXITCODE -ne 0) {
        throw "SCP transfer failed with exit code $LASTEXITCODE"
    }
    Write-Output "SCP transfer completed successfully."
}
catch {
    Write-Error "An error occurred during SCP transfer: $_"
    exit 1
}
