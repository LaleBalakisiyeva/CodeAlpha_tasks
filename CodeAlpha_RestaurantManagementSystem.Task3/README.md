# Restaurant Management System API

A scalable, N-Tier architecture Web API built with .NET 8.0 and Entity Framework Core 8.0. This service manages daily restaurant operations, including menu items, tables, reservations, orders, and inventory tracking.

## Architecture & Project Structure

The solution follows clean N-Tier architectural principles with strict layer isolation:
* **Core:** Contains domain entities (`MenuItem`, `Table`, `Reservation`, `Order`, `InventoryItem`), core interfaces (`IGenericRepository`, `IUnitOfWork`), and shared abstractions (`BaseEntity`). Free from external framework dependencies.
* **DAL (Data Access Layer):** Houses `AppDbContext`, Fluent API entity configurations (`IEntityTypeConfiguration`), EF Core implementations for Generic Repository and Unit of Work, and DI registration extensions (`DalServiceRegistration`).
* **Business:** Implements business rules (Domain Services), Data Transfer Objects (DTOs), AutoMapper profiles, FluentValidation rules, custom exceptions, and DI registration extensions (`BusinessServiceRegistration`).
* **API:** Composition root hosting REST Controllers (`MenuItemsController`, `OrdersController`, etc.), `Program.cs` configuration, middleware execution, and Swagger UI integration.

## Key Design Patterns & Principles

* **N-Tier Architecture:** Clear separation of concerns across presentation, business logic, data access, and domain core layers.
* **Generic Repository & Unit of Work:** Encapsulates data access and coordinates single database transaction commits.
* **Dependency Injection Extensions:** Uses custom extension methods (`AddDalServices`, `AddBusinessServices`) to keep `Program.cs` clean and modular.
* **Fluent API Configuration:** Explicit database mapping decoupled from entity definitions.

## NuGet Packages Installed

| Layer | Package Name | Version / Description |
| :--- | :--- | :--- |
| **DAL** | `Microsoft.EntityFrameworkCore.SqlServer` | 8.0.x - SQL Server Provider |
| **DAL** | `Microsoft.EntityFrameworkCore.Tools` | 8.0.x - Migrations & CLI Tools |
| **Business** | `AutoMapper` | 13.0.1+ - Object-to-object mapping |
| **Business** | `FluentValidation.DependencyInjectionExtensions` | 11.9.0+ - Request validation |
| **Business** | `Microsoft.Extensions.DependencyInjection.Abstractions` | 8.0.0+ - DI extension support |
| **API** | `Swashbuckle.AspNetCore` | 6.5.0+ - Swagger documentation |

## API Endpoints Overview

The API provides full CRUD operations for all major entities. Below are a few key examples:

**1. Create a Reservation**
* **HTTP Method:** `POST`
* **Route:** `/api/Reservations`
* **Request Body:**
```json
{
  "tableId": 1,
  "customerName": "John Doe",
  "customerPhone": "+123456789",
  "reservationTime": "2026-10-15T19:00:00",
  "guestCount": 4
}
Response: 201 Created

2. Place an Order

HTTP Method: POST

Route: /api/Orders

Request Body:

JSON
{
  "tableId": 1,
  "items": [
    {
      "menuItemId": 1,
      "quantity": 2
    }
  ]
}
Response: 201 Created

3. Get All Menu Items

HTTP Method: GET

Route: /api/MenuItems

Response: 200 OK (Returns a list of available menu items)

(Note: Similar endpoints exist for /api/Tables and /api/Inventory)

Setup & Running the Project
Prerequisites
.NET 8.0 SDK

SQL Server / LocalDB

Database Setup
Update the connection string in API/appsettings.json under ConnectionStrings:DefaultConnection.

Open Package Manager Console or Terminal and run migrations:

Bash
dotnet ef database update --project CodeAlpha_RestaurantManagementSystem.DAL --startup-project CodeAlpha_RestaurantManagementSystem.API
Execution
Run the API project via Visual Studio (F5) or Terminal:

Bash
dotnet run --project CodeAlpha_RestaurantManagementSystem.API
Navigate to https://localhost:{PORT}/swagger to test endpoints via Swagger UI.
