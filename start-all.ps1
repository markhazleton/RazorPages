# WiredBrainCoffee - Start All Projects
# This script starts all three web projects in the correct order

Write-Host "================================================" -ForegroundColor Cyan
Write-Host " WiredBrainCoffee - Starting All Projects" -ForegroundColor Cyan
Write-Host "================================================" -ForegroundColor Cyan
Write-Host ""

# Start API in new PowerShell window
Write-Host "[1/3] Starting API (WiredBrainCoffee.API)..." -ForegroundColor Yellow
Start-Process powershell -ArgumentList "-NoExit", "-Command", `
    "Write-Host 'WiredBrainCoffee.API' -ForegroundColor Green; " +
    "cd '$PSScriptRoot\WiredBrainCoffee.API'; " +
    "dotnet run"

Write-Host "      Waiting for API to initialize..." -ForegroundColor Gray
Start-Sleep -Seconds 8

# Start Razor Pages in new PowerShell window
Write-Host "[2/3] Starting Razor Pages (WiredBrainCoffee)..." -ForegroundColor Yellow
Start-Process powershell -ArgumentList "-NoExit", "-Command", `
    "Write-Host 'WiredBrainCoffee (Razor Pages)' -ForegroundColor Green; " +
    "cd '$PSScriptRoot\WiredBrainCoffee'; " +
    "dotnet run"

Start-Sleep -Seconds 2

# Start Blazor UI in new PowerShell window
Write-Host "[3/3] Starting Blazor UI (WiredBrainCoffee.UI)..." -ForegroundColor Yellow
Start-Process powershell -ArgumentList "-NoExit", "-Command", `
    "Write-Host 'WiredBrainCoffee.UI (Blazor WebAssembly)' -ForegroundColor Green; " +
    "cd '$PSScriptRoot\WiredBrainCoffee.UI'; " +
    "dotnet run"

Write-Host ""
Write-Host "================================================" -ForegroundColor Cyan
Write-Host " All Projects Starting!" -ForegroundColor Green
Write-Host "================================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Project URLs (will open shortly):" -ForegroundColor White
Write-Host "  API Swagger:  https://localhost:7024/swagger" -ForegroundColor Cyan
Write-Host "  Razor Pages:  https://localhost:5001" -ForegroundColor Cyan
Write-Host "  Blazor UI:    https://localhost:5002" -ForegroundColor Cyan
Write-Host ""
Write-Host "Waiting for all services to be ready..." -ForegroundColor Gray
Start-Sleep -Seconds 5

# Open browsers
Write-Host "Opening browsers..." -ForegroundColor Yellow
Start-Process "https://localhost:7024/swagger"
Start-Sleep -Seconds 1
Start-Process "https://localhost:5001"
Start-Sleep -Seconds 1
Start-Process "https://localhost:5002"

Write-Host ""
Write-Host "All projects started!" -ForegroundColor Green
Write-Host "Close the individual PowerShell windows to stop each project." -ForegroundColor Yellow
Write-Host ""
