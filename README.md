# CodeAlpha Internship Projects

A collection of backend projects developed during my **Software Development Internship at CodeAlpha**, using **C# and .NET 8**.

The projects demonstrate practical experience with **N-Tier Architecture, ASP.NET Core Web API, Entity Framework Core, SQL Server, RESTful APIs, Repository and Unit of Work patterns, Dependency Injection, validation, and middleware**.

---

## Projects

### 1. Simple URL Shortener API

A RESTful Web API that converts long URLs into unique short codes and redirects users to the original URLs.

**Main Features:**
- Create shortened URLs
- Redirect short codes to original URLs
- RESTful API endpoints
- Entity Framework Core
- SQL Server
- Swagger API documentation

**Architecture:**
- Core
- DAL
- Business
- API

**Key Patterns & Principles:**
- N-Tier Architecture
- Generic Repository
- Unit of Work
- Dependency Injection
- Fluent API Configuration
- DTOs
- AutoMapper
- FluentValidation

---

### 2. Event Registration System API

A backend Web API designed to manage events, users, and event registrations.

**Main Features:**
- Create and manage events
- Register users for events
- Retrieve event registrations
- Data validation
- Global exception handling
- RESTful API endpoints

**Architecture:**
- Core
- DAL
- Business
- API

**Key Patterns & Principles:**
- N-Tier Architecture
- Generic Repository
- Unit of Work
- Dependency Injection
- Global Exception Handling Middleware
- DTOs
- AutoMapper
- FluentValidation

---

### 3. Restaurant Management System API

A backend Web API for managing daily restaurant operations.

**Main Features:**
- Menu item management
- Table management
- Reservations
- Orders
- Inventory tracking
- Full CRUD operations
- RESTful API endpoints

**Architecture:**
- Core
- DAL
- Business
- API

**Key Patterns & Principles:**
- N-Tier Architecture
- Generic Repository
- Unit of Work
- Dependency Injection
- Fluent API Configuration
- DTOs
- AutoMapper
- FluentValidation
- Middleware

---

## Technologies

### Backend
- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core 8

### Database
- SQL Server
- SQL Server LocalDB
- EF Core Migrations

### Architecture & Design
- N-Tier Architecture
- Repository Pattern
- Unit of Work Pattern
- Dependency Injection
- Separation of Concerns
- DTO Pattern

### Libraries & Tools
- AutoMapper
- FluentValidation
- Swagger / OpenAPI
- Git
- GitHub
- Visual Studio

---

## Common Architecture

The projects follow a layered N-Tier architecture:

```text
                API
                 │
                 ▼
             Business
                 │
                 ▼
               DAL
                 │
                 ▼
               Core
                 │
                 ▼
             SQL Server
Core

Contains domain entities, interfaces, and shared abstractions.

DAL

Handles database access using Entity Framework Core, repositories, Unit of Work, and entity configurations.

Business

Contains business logic, DTOs, validation rules, AutoMapper profiles, custom exceptions, and service registrations.

API

Contains REST controllers, application configuration, middleware, dependency injection, and Swagger documentation.

API Documentation

Each project includes Swagger/OpenAPI documentation for testing and exploring the available endpoints.

After running a project locally, Swagger can be accessed at:

https://localhost:{PORT}/swagger
Database Setup
Prerequisites
.NET 8 SDK
SQL Server or SQL Server LocalDB
Visual Studio

Each project uses Entity Framework Core migrations for database creation and updates.

Example:

dotnet ef database update

The connection string can be configured in the project's:

appsettings.json
