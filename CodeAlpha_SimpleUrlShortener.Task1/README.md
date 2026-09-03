# Simple URL Shortener API

A scalable, N-Tier architecture Web API built with **.NET 8.0** and **Entity Framework Core 8.0**. This service converts long URLs into unique short codes and automatically redirects users to the original URL upon access.

---

## Architecture & Project Structure

The solution follows clean N-Tier architectural principles with strict layer isolation:

*   **`Core`**: Contains domain entities, core interfaces (`IGenericRepository`, `IUnitOfWork`), and shared abstractions. Free from external framework dependencies.
*   **`DAL` (Data Access Layer)**: Houses `AppDbContext`, Fluent API entity configurations (`IEntityTypeConfiguration`), EF Core implementations for Generic Repository and Unit of Work, and DI registration extensions (`DalServiceRegistration`).
*   **`Business`**: Implements business rules (`UrlService`), Data Transfer Objects (DTOs), AutoMapper profiles, FluentValidation rules, custom exceptions (`NotFoundException`), and DI registration extensions (`BusinessServiceRegistration`).
*   **`API`**: Composition root hosting `UrlsController`, `Program.cs` configuration, middleware execution, and Swagger UI integration.

---

## Key Design Patterns & Principles

*   **N-Tier Architecture**: Clear separation of concerns across presentation, business logic, data access, and domain core layers.
*   **Generic Repository & Unit of Work**: Encapsulates data access and coordinates single database transaction commits.
*   **Dependency Injection Extensions**: Uses custom extension methods (`AddDalServices`, `AddBusinessServices`) to keep `Program.cs` clean and modular.
*   **Fluent API Configuration**: Explicit database mapping decoupled from entity definitions.

---

## NuGet Packages Installed

| Layer | Package Name | Version / Description |
| :--- | :--- | :--- |
| **DAL** | `Microsoft.EntityFrameworkCore.SqlServer` | **8.0.x** - SQL Server Provider |
| | `Microsoft.EntityFrameworkCore.Tools` | **8.0.x** - Migrations & CLI Tools |
| **Business** | `AutoMapper` | **13.0.1+** - Object-to-object mapping |
| | `FluentValidation.DependencyInjectionExtensions` | **11.9.0+** - Request validation |
| | `Microsoft.Extensions.DependencyInjection.Abstractions` | **8.0.0+** - DI extension support |
| **API** | `Swashbuckle.AspNetCore` | **6.5.0+** - Swagger documentation |

---

## API Endpoints

### 1. Create Short URL
*   **HTTP Method:** `POST`
*   **Route:** `/api/Urls/shorten`
*   **Request Body:**
    ```json
    {
      "originalUrl": "[https://www.example.com/very/long/url/path](https://www.example.com/very/long/url/path)"
    }
    ```
*   **Response (200 OK):**
    ```json
    {
      "shortCode": "mZufy6",
      "shortUrl": "https://localhost:7123/mZufy6"
    }
    ```

### 2. Redirect to Original URL
*   **HTTP Method:** `GET`
*   **Route:** `/{shortCode}`
*   **Response:** `302 Found` (Redirects directly in the browser to the original URL) or `404 Not Found` if the code does not exist.

---

## Setup & Running the Project

### Prerequisites
*   [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
*   SQL Server / LocalDB

### Database Setup
1. Update connection string in `API/appsettings.json` under `ConnectionStrings:DefaultConnection`.
2. Open Package Manager Console or Terminal and run migrations:
   ```powershell
   dotnet ef database update --project CodeAlpha_SimpleUrlShortener.DAL --startup-project CodeAlpha_SimpleUrlShortener.API                                          
Execution
Run the API project via Visual Studio (F5) or Terminal:

PowerShell
dotnet run --project CodeAlpha_SimpleUrlShortener.API
Navigate to https://localhost:{PORT}/swagger to test endpoints via Swagger UI.
