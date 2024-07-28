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

try {
    & $scpPath -vvv -i $sshKeyPath $sourcePath $destPath
    if ($LASTEXITCODE -ne 0) {
        throw "SCP transfer failed with exit code $LASTEXITCODE"
    }
    Write-Output "SCP transfer completed successfully."
} catch {
    Write-Error "An error occurred: $_"
}
