# WiredBrainCoffee - Startup Guide

## Overview
This solution contains 3 runnable web projects that need to be started in a specific order.

---

## Port Configuration

| Project | HTTPS Port | HTTP Port | Purpose |
|---------|------------|-----------|---------|
| **WiredBrainCoffee.API** | 7024 | 5024 | Backend API (Controllers + MinApi + SignalR) |
| **WiredBrainCoffee** (Razor Pages) | 5001 | 5000 | Server-Side Rendered Frontend |
| **WiredBrainCoffee.UI** (Blazor WASM) | 5002 | 5003 | Client-Side SPA Frontend |

---

## Startup Order (IMPORTANT!)

The projects **must be started in this order**:

### **1. Start the API First** (Required)
Both frontends depend on the API, so start it first.

```powershell
cd WiredBrainCoffee.API
dotnet run
```

**Expected Output:**
```
Now listening on: https://localhost:7024
Now listening on: http://localhost:5024
Application started. Press Ctrl+C to shut down.
```

**Wait for**: "Database migration completed successfully" message

---

### **2. Start Razor Pages** (Optional - Demo #1)
In a **NEW terminal window**:

```powershell
cd WiredBrainCoffee
dotnet run
```

**Expected Output:**
```
Now listening on: https://localhost:5001
Now listening on: http://localhost:5000
Application started.
```

**Navigate to**: https://localhost:5001

---

### **3. Start Blazor WebAssembly** (Optional - Demo #2)
In a **NEW terminal window**:

```powershell
cd WiredBrainCoffee.UI
dotnet run
```

**Expected Output:**
```
Now listening on: https://localhost:5002
Now listening on: http://localhost:5003
Application started.
```

**Navigate to**: https://localhost:5002

---

## Visual Studio Multiple Startup

If using Visual Studio, configure multiple startup projects:

1. Right-click **Solution** ? **Properties**
2. Select **Multiple startup projects**
3. Set startup order:
   - ? WiredBrainCoffee.API ? **Start**
   - ? WiredBrainCoffee ? **Start** (optional)
   - ? WiredBrainCoffee.UI ? **Start** (optional)

?? **Visual Studio will start them in alphabetical order, which is incorrect!**

**Better approach**: Use individual terminal windows as shown above.

---

## Troubleshooting Common Issues

### Issue 1: "Address already in use" / Port Conflict
**Cause**: Previous instance still running or port in use

**Solution**:
```powershell
# Find processes using the ports
netstat -ano | findstr :7024
netstat -ano | findstr :5001
netstat -ano | findstr :5002

# Kill the process (replace <PID> with actual process ID)
taskkill /PID <PID> /F
```

---

### Issue 2: "Unable to connect to API" / API Call Failures
**Cause**: API not started or not ready yet

**Solution**:
1. Make sure API is started FIRST
2. Wait for "Database migration completed successfully"
3. Verify API is accessible: https://localhost:7024/swagger

---

### Issue 3: SSL/Certificate Errors
**Cause**: Development certificates not trusted

**Solution**:
```powershell
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

Restart your browser after running these commands.

---

### Issue 4: Blazor WASM "Failed to fetch"
**Cause**: API not running or CORS issues

**Solution**:
1. Verify API is running on port 7024
2. Check browser console for specific error
3. Verify `appsettings.json` has correct API URL: `https://localhost:7024/`

---

### Issue 5: Razor Pages Shows Empty Menu
**Cause**: API not accessible or MenuService not calling API

**Solution**:
1. Verify API is running
2. Check API health: https://localhost:7024/health
3. Check API menu endpoint: https://localhost:7024/menu
4. Verify `appsettings.json` has: `"ApiSettings:BaseUrl": "https://localhost:7024/"`

---

## Quick Start Scripts

### PowerShell Script (Windows)
Create a file `start-all.ps1`:

```powershell
# Start API in background
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd WiredBrainCoffee.API; dotnet run"

# Wait for API to be ready
Start-Sleep -Seconds 5

# Start Razor Pages
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd WiredBrainCoffee; dotnet run"

# Start Blazor UI
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd WiredBrainCoffee.UI; dotnet run"

Write-Host "All projects starting..."
Write-Host "API: https://localhost:7024"
Write-Host "Razor Pages: https://localhost:5001"
Write-Host "Blazor UI: https://localhost:5002"
```

Run it:
```powershell
.\start-all.ps1
```

---

### Bash Script (Mac/Linux)
Create a file `start-all.sh`:

```bash
#!/bin/bash

# Start API in background
cd WiredBrainCoffee.API
dotnet run &
API_PID=$!

# Wait for API to be ready
sleep 5

# Start Razor Pages in background
cd ../WiredBrainCoffee
dotnet run &
RAZOR_PID=$!

# Start Blazor UI
cd ../WiredBrainCoffee.UI
dotnet run &
BLAZOR_PID=$!

echo "All projects starting..."
echo "API: https://localhost:7024 (PID: $API_PID)"
echo "Razor Pages: https://localhost:5001 (PID: $RAZOR_PID)"
echo "Blazor UI: https://localhost:5002 (PID: $BLAZOR_PID)"
echo ""
echo "Press Ctrl+C to stop all services"

# Wait for user interrupt
trap "kill $API_PID $RAZOR_PID $BLAZOR_PID" EXIT
wait
```

Make executable and run:
```bash
chmod +x start-all.sh
./start-all.sh
```

---

## Verifying Each Project

### Verify API
```powershell
# Health check
curl https://localhost:7024/health

# Swagger UI
Start-Process "https://localhost:7024/swagger"

# Menu endpoint
curl https://localhost:7024/menu
```

### Verify Razor Pages
```powershell
# Home page
Start-Process "https://localhost:5001"

# Menu page (calls API)
Start-Process "https://localhost:5001/menu"
```

### Verify Blazor UI
```powershell
# Home page
Start-Process "https://localhost:5002"

# Admin dashboard (calls API)
Start-Process "https://localhost:5002/admin"
```

---

## Stopping All Projects

### Individual Windows
Press `Ctrl+C` in each terminal window

### If Running in Background
```powershell
# Windows - Kill all dotnet processes
Get-Process dotnet | Stop-Process -Force

# Or kill specific ports
Get-NetTCPConnection -LocalPort 7024 | Select-Object -ExpandProperty OwningProcess | ForEach-Object { Stop-Process -Id $_ -Force }
```

---

## What Each Project Does

### **WiredBrainCoffee.API** (Backend)
- REST API endpoints (MenuController, ContactController, OrdersController)
- Minimal API endpoints (/orders/*, /order-status, /health)
- SignalR Hub for real-time chat (/chathub)
- Entity Framework Core + SQLite database
- Swagger documentation at /swagger

**Must be running for other projects to work!**

---

### **WiredBrainCoffee** (Razor Pages Frontend)
- Server-Side Rendered web application
- Pages: Index, Menu, Contact, Feedback, Item
- Demonstrates traditional ASP.NET Core Razor Pages
- Calls API for menu data via HttpClient
- Good for SEO-critical pages

**Requires API to be running**

---

### **WiredBrainCoffee.UI** (Blazor WebAssembly Frontend)
- Client-Side SPA (runs C# in browser via WebAssembly)
- Components: Order management, Admin dashboard, Order history
- Demonstrates modern Blazor WebAssembly SPA
- Calls API for all data via HttpClient
- SignalR integration for real-time updates
- Good for interactive, dashboard-style applications

**Requires API to be running**

---

## Architecture Summary

```
????????????????????         ????????????????????
?  Razor Pages     ?         ?   Blazor WASM    ?
?  Port: 5001      ?         ?   Port: 5002     ?
?  Server-Side     ?         ?   Client-Side    ?
????????????????????         ????????????????????
         ?                            ?
         ?  HTTP GET /menu            ?  HTTP GET /menu
         ?  HTTP GET /orders          ?  HTTP GET /orders
         ?                            ?
         ??????????????????????????????
                      ?
                      ?
            ???????????????????
            ?   API Server    ?
            ?   Port: 7024    ?
            ?                 ?
            ? - MenuService   ?
            ? - OrderService  ?
            ? - SignalR Hub   ?
            ? - SQLite DB     ?
            ???????????????????
```

**Both frontends share the same backend API for data consistency!**

---

## Development URLs

| Service | URL | Description |
|---------|-----|-------------|
| API Swagger | https://localhost:7024/swagger | Interactive API documentation |
| API Health | https://localhost:7024/health | Health check endpoint |
| API Menu | https://localhost:7024/menu | Menu items JSON |
| API Orders | https://localhost:7024/orders | Orders JSON |
| Razor Pages | https://localhost:5001 | Traditional web app |
| Razor Pages Menu | https://localhost:5001/menu | Menu page (calls API) |
| Blazor UI | https://localhost:5002 | SPA application |
| Blazor Admin | https://localhost:5002/admin | Admin dashboard |

---

## Summary

**To run the full solution:**

1. ? Start **WiredBrainCoffee.API** first (port 7024)
2. ? Wait for "Database migration completed successfully"
3. ? Start **WiredBrainCoffee** (Razor Pages) - optional (port 5001)
4. ? Start **WiredBrainCoffee.UI** (Blazor) - optional (port 5002)

**Key Point**: The API must be running for either frontend to work. Both frontends consume the same API for data consistency while demonstrating different technology approaches.

---

*Last Updated: Auto-generated during consolidation*
