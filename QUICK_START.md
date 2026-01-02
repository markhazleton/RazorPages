# Quick Start - WiredBrainCoffee Solution

## ? Fastest Way to Start Everything

### Option 1: Use the PowerShell Script (Recommended)
```powershell
.\start-all.ps1
```

This will:
- ? Start API first (port 7024)
- ? Wait for API to initialize
- ? Start Razor Pages (port 5001)
- ? Start Blazor UI (port 5002)
- ?? Open all three in your browser

---

### Option 2: Manual Startup (Step-by-Step)

#### 1?? Start API (Required)
```powershell
cd WiredBrainCoffee.API
dotnet run
```
**Wait for:** "Database migration completed successfully"

#### 2?? Start Razor Pages (New Terminal)
```powershell
cd WiredBrainCoffee
dotnet run
```

#### 3?? Start Blazor UI (New Terminal)
```powershell
cd WiredBrainCoffee.UI
dotnet run
```

---

## ?? Access Points

| Service | URL | What It Is |
|---------|-----|------------|
| **API** | https://localhost:7024/swagger | Backend API with Swagger docs |
| **Razor Pages** | https://localhost:5001 | Server-side rendered frontend |
| **Blazor UI** | https://localhost:5002 | Client-side SPA frontend |

---

## ?? Troubleshooting

### "Address already in use" Error
```powershell
# Kill all dotnet processes
Get-Process dotnet | Stop-Process -Force
```

### "Unable to connect to API"
1. Make sure API is started FIRST
2. Check https://localhost:7024/health

### SSL Certificate Issues
```powershell
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

---

## ?? Full Documentation

For detailed information, see:
- **STARTUP_GUIDE.md** - Complete startup instructions and troubleshooting
- **ARCHITECTURE_COMPARISON.md** - Technology comparison between Razor Pages and Blazor
- **CONSOLIDATION_SUMMARY.md** - Full solution architecture and changes

---

## ?? What Each Project Does

### WiredBrainCoffee.API
Backend API providing:
- Menu data
- Order management
- Contact form handling
- SignalR real-time chat

### WiredBrainCoffee (Razor Pages)
Traditional server-side web app demonstrating:
- Server-side rendering
- SEO-friendly pages
- Form handling with PageModels

### WiredBrainCoffee.UI (Blazor WebAssembly)
Modern SPA demonstrating:
- Client-side C# in the browser
- Rich interactive UI
- Real-time updates with SignalR

**Both frontends use the same API for data consistency!**

---

*For more details, see STARTUP_GUIDE.md*
