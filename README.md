# Warehouse App

A simple **ASP.NET Core** web application for managing warehouse inventory. Built with Entity Framework Core and ASP.NET Core Identity for user authentication.

## Features

- User authentication and authorization (Register / Login with ASP.NET Core Identity)
- CRUD operations for warehouse items (products)
- Product fields: SKU, Category, Quantity, and more
- Entity Framework Core with SQL Server support
- Razor Pages + MVC controllers
- Responsive design with Bootstrap
- Database migrations support

## Technologies Used

- **Backend**: ASP.NET Core (.NET 8 / .NET 9)
- **Database**: SQL Server + Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **Frontend**: Razor Pages / MVC with Bootstrap 5
- **ORM**: Entity Framework Core

## Prerequisites

Before running the project, make sure you have:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or higher
- SQL Server (LocalDB, SQL Express, or full SQL Server)
- Visual Studio 2022 (recommended) or VS Code
  
## Common Issues & Fixes

SSL Certificate Error: Add TrustServerCertificate=True to the connection string.
Login Failed: Make sure the database exists and your user has permissions (or use SQL Authentication with sa).
No DbContext found: Add a parameterless constructor or IDesignTimeDbContextFactory.
404 on Identity pages: Ensure app.MapRazorPages() is called in Program.cs.

## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/Gopet0/Warehouse-app.git
cd Warehouse-app

