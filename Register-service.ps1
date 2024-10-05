# Register-Service.ps1
$serviceName = "MyPowerShellService"
$serviceScriptPath = "C:\MyService\MyService.ps1"

# Ensure the service folder exists
$serviceFolder = "C:\MyService"
if (!(Test-Path -Path $serviceFolder)) {
    New-Item -Path $serviceFolder -ItemType Directory
}

# Download NSSM if not already present
$nssmPath = "C:\MyService\nssm.exe"
if (!(Test-Path -Path $nssmPath)) {
    Invoke-WebRequest -Uri "https://nssm.cc/release/nssm-2.24.zip" -OutFile "$serviceFolder\nssm.zip"
    Expand-Archive -Path "$serviceFolder\nssm.zip" -DestinationPath $serviceFolder
    Copy-Item -Path "$serviceFolder\nssm-2.24\win64\nssm.exe" -Destination $nssmPath
}

# Register the service
& $nssmPath install $serviceName "powershell.exe" "-File $serviceScriptPath"
& $nssmPath set $serviceName Start SERVICE_AUTO_START
& $nssmPath start $serviceName
Write-Host "Service '$serviceName' has been installed and started."
