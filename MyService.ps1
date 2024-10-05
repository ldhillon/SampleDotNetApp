# MyService.ps1
$logPath = "C:\MyService\service.log"
while ($true) {
    $timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
    Add-Content -Path $logPath -Value "Service is running at $timestamp"
    Start-Sleep -Seconds 60
}