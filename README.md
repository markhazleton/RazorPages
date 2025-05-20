# Wired Brain Coffee - Full Stack Demo

Welcome to the **Wired Brain Coffee** solution! This repository demonstrates a modern, full-stack .NET application using Razor Pages, Blazor WebAssembly, ASP.NET Core APIs, and Minimal APIs. It is designed as a reference for best practices in architecture, code organization, and developer experience.

---

## Credits & Inspiration

- **Original Author:** [alex-wolf-ps](https://github.com/alex-wolf-ps)
- **Source of this fork:** [alex-wolf-ps/RazorPages](https://github.com/alex-wolf-ps/RazorPages)
- **Inspiration:** This project is a fork and creative extension by Mark Hazleton, building on the excellent foundation and ideas from the original repository.

---

## Solution Overview

This repository contains several projects, each with a distinct role:

### 1. `WiredBrainCoffee` (Razor Pages Web App)

- **Type:** ASP.NET Core Razor Pages
- **Purpose:** Traditional server-rendered web application for Wired Brain Coffee.
- **Features:**
  - Home, Menu, Contact, and Feedback pages
  - Responsive Bootstrap UI
  - Menu browsing and details
  - Contact and feedback forms
  - Community and promotional sections
  - Follows best practices for Razor Pages structure

### 2. `WiredBrainCoffee.UI` (Blazor WebAssembly SPA)

- **Type:** Blazor WebAssembly (SPA)
- **Purpose:** Modern, client-side single-page application for Wired Brain Coffee.
- **Features:**
  - Interactive UI with Blazorise and Bootstrap
  - Coffee and food ordering with tabbed navigation
  - Dynamic menu loading from API
  - Real-time chat (SignalR)
  - Customer and partner contact forms with file upload
  - Admin dashboard (extensible)
  - Mailing list and contact info components
  - Modern, mobile-friendly design

### 3. `WiredBrainCoffee.API` (ASP.NET Core Web API)

- **Type:** ASP.NET Core Web API
- **Purpose:** Backend API for menu, orders, and contact endpoints.
- **Features:**
  - RESTful endpoints for menu and orders
  - Contact submission with file handling
  - SignalR chat hub for real-time communication
  - Integrated Swagger/OpenAPI documentation
  - CORS and HTTP logging for security and diagnostics

### 4. `WiredBrainCoffee.MinApi` (Minimal API + EF Core)

- **Type:** ASP.NET Core Minimal API
- **Purpose:** Lightweight, high-performance API for order management.
- **Features:**
  - Minimal API endpoints for CRUD operations on orders
  - Health checks and system status endpoint
  - Entity Framework Core with SQLite for persistence
  - CORS, response compression, and Swagger UI
  - Example of modern .NET minimal API patterns

### 5. `WiredBrainCoffee.Models` (Shared Models)

- **Type:** .NET Class Library
- **Purpose:** Shared data models for menu items, orders, contacts, and more.
- **Features:**
  - Strongly-typed models for use across all projects
  - Includes menu, order, contact, and supporting types
  - Promotes code reuse and consistency

---

## Getting Started

1. **Clone the repository:**

   ```pwsh
   git clone https://github.com/MarkHazleton/RazorPages.git
   ```

2. **Open in Visual Studio 2022+ or VS Code**

3. **Build the solution** to restore dependencies.

4. **Run the projects** as needed:
   - `WiredBrainCoffee` for the Razor Pages web app
   - `WiredBrainCoffee.UI` for the Blazor WebAssembly SPA
   - `WiredBrainCoffee.API` and/or `WiredBrainCoffee.MinApi` for backend APIs

## Best Practices Demonstrated

- Clean separation of concerns (UI, API, Models)
- Modern .NET patterns: Razor Pages, Blazor, Minimal APIs
- Strongly-typed shared models
- Responsive, accessible UI with Bootstrap/Blazorise
- Real-time features with SignalR
- Secure file upload and CORS configuration
- Automated API documentation (Swagger)
- Health checks and diagnostics

## Contributing

Contributions are welcome! Please open issues or submit pull requests to help improve this demo.

## License

This project is licensed under the MIT License.

---

**Wired Brain Coffee** – Brewed for developers. Enjoy exploring this full-stack .NET reference!
