# Event Registration System API

A scalable, N-Tier architecture Web API built with .NET 8.0 and Entity Framework Core 8.0. This service is designed to manage users, events, and their registrations cleanly and efficiently, ensuring robust data validation and error handling.

## Architecture & Project Structure

The solution follows clean N-Tier architectural principles with strict layer isolation:
* **Core:** Contains domain entities (`Event`, `User`, `Registration`, `BaseEntity`), core interfaces (`IGenericRepository`, `IUnitOfWork`), and specific repository interfaces. Free from external framework dependencies.
* **DAL (Data Access Layer):** Houses `AppDbContext`, EF Core implementations for the Generic Repository and Unit of Work, database migrations, and DI registration extensions (`DalServiceRegistration`).
* **Business:** Implements business rules (`EventService`, `UserService`, `RegistrationService`), Data Transfer Objects (DTOs), AutoMapper profiles, FluentValidation rules, custom exceptions (`NotFoundException`, `BadRequestException`), and DI registration extensions (`BusinessServiceRegistration`).
* **API:** Composition root hosting RESTful controllers (`EventsController`, `UsersController`, `RegistrationsController`), `Program.cs` configuration, custom Global Exception Handling Middleware, and Swagger UI integration.

## Key Design Patterns & Principles

* **N-Tier Architecture:** Clear separation of concerns across presentation, business logic, data access, and domain core layers.
* **Generic Repository & Unit of Work:** Encapsulates data access and coordinates single database transaction commits.
* **Global Exception Handling:** Uses custom middleware to centrally manage exceptions, returning clean and consistent JSON error responses while eliminating repetitive `try-catch` blocks in services.
* **Dependency Injection Extensions:** Uses custom extension methods (`AddDalServices`, `AddBusinessServices`) to keep `Program.cs` clean and modular.

## NuGet Packages Installed

| Layer | Package Name | Version / Description |
| :--- | :--- | :--- |
| **DAL** | `Microsoft.EntityFrameworkCore.SqlServer` | 8.0.x - SQL Server Provider |
| **DAL** | `Microsoft.EntityFrameworkCore.Tools` | 8.0.x - Migrations & CLI Tools |
| **Business** | `AutoMapper` | 13.x - Object-to-object mapping |
| **Business** | `FluentValidation.DependencyInjectionExtensions` | 12.1.1 - Strongly-typed request validation |
| **API** | `Swashbuckle.AspNetCore` | 6.5.0+ - Swagger documentation |

## Key API Endpoints

### 1. Create a New Event
* **HTTP Method:** `POST`
* **Route:** `/api/Events`
* **Request Body:**
```json
{
  "title": "C# Masterclass",
  "description": "Deep dive into .NET 8 and Web APIs",
  "eventDate": "2026-10-15T10:00:00Z",
  "location": "Baku, Azerbaijan"
}
Response (201 Created): Returns the created event object including its generated id.

2. Register a User for an Event
HTTP Method: POST

Route: /api/Registrations

Request Body:

JSON
{
  "eventId": 1,
  "userId": 1
}
Response (200 OK): Returns the successful registration details.

3. Get All Registrations
HTTP Method: GET

Route: /api/Registrations

Response (200 OK): Returns a list of all event registrations, including the mapped event titles and user names.

Setup & Running the Project
Prerequisites
.NET 8.0 SDK

SQL Server / LocalDB

Database Setup
Update the connection string in API/appsettings.json under ConnectionStrings:DefaultConnection.

Open Package Manager Console or Terminal and run migrations:

PowerShell
dotnet ef database update --project CodeAlpha_EventRegistrationSystem.DAL --startup-project CodeAlpha_EventRegistrationSystem.API
Execution
Run the API project via Visual Studio (F5) or Terminal:

PowerShell
dotnet run --project CodeAlpha_EventRegistrationSystem.API
Navigate to https://localhost:{PORT}/swagger in your browser to test the endpoints via Swagger UI.
