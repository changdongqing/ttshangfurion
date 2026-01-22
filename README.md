# TTShang Solution

A complete .NET solution built with Furion framework, Ant Design Blazor (Server mode), EF Core, and PostgreSQL following Domain-Driven Design (DDD) architecture principles.

## Architecture

The solution is structured following DDD principles with clear separation of concerns:

### Domain Layer (TTShang.Core)
- **Entities**: Domain entities like `Student`
- **Repositories**: Repository interfaces for data access abstraction (`IStudentRepository`)

### Application Layer (TTShang.Application)
- **Services**: Application services implementing business logic (`IStudentService`, `StudentService`)
- Orchestrates domain objects and coordinates application activities

### Infrastructure Layer (TTShang.Database.Adapter)
- **Context**: EF Core DbContext for database operations (`TTShangDbContext`)
- **Repositories**: Concrete repository implementations (`StudentRepository`)
- Configured for PostgreSQL database

### Presentation Layer
- **TTShang.Web.Core**: Web configuration and shared web logic
- **TTShang.Web.Entry**: Blazor Server application with Ant Design Blazor UI

## Technology Stack

- **.NET 10.0**: Latest .NET framework
- **Furion 4.9.8.1**: Modern web application framework for .NET
- **Ant Design Blazor 1.5.1**: Enterprise-class UI components for Blazor
- **Entity Framework Core 10.0**: ORM for data access
- **Npgsql 10.0**: PostgreSQL provider for EF Core
- **Blazor Server**: Interactive server-side UI framework

## Features

### Student Management
The solution includes a complete CRUD interface for Student management:
- **List**: View all students in a table
- **Create**: Add new students using a modal form
- **Update**: Edit existing student information
- **Delete**: Remove students with confirmation

### Student Entity
- `Id`: Unique identifier (Guid)
- `Name`: Student name (string)
- `Age`: Student age (integer)
- `Gender`: Student gender (string)

## Getting Started

### Prerequisites
- .NET 10.0 SDK
- PostgreSQL database server
- IDE (Visual Studio 2022, Visual Studio Code, or Rider)

### Database Setup
1. Install PostgreSQL if not already installed
2. Create a database named `ttshang`
3. Update the connection string in `TTShang.Web.Entry/appsettings.json` if needed:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=ttshang;Username=postgres;Password=postgres"
   }
   ```

### Running the Application
1. Clone the repository
2. Open a terminal in the solution directory
3. Restore packages:
   ```bash
   dotnet restore
   ```
4. Build the solution:
   ```bash
   dotnet build
   ```
5. Run the Web.Entry project:
   ```bash
   cd TTShang.Web.Entry
   dotnet run
   ```
6. Open a browser and navigate to the URL shown in the terminal (typically `https://localhost:5001`)
7. Click on "Students" in the navigation menu to access the student management interface

### Database Migration
To create the database schema:
```bash
cd TTShang.Database.Adapter
dotnet ef migrations add InitialCreate --startup-project ../TTShang.Web.Entry
dotnet ef database update --startup-project ../TTShang.Web.Entry
```

## Project Structure

```
TTShang/
├── TTShang.sln                      # Solution file
├── TTShang.Core/                    # Domain layer
│   ├── Entities/
│   │   └── Student.cs
│   └── Repositories/
│       └── IStudentRepository.cs
├── TTShang.Application/             # Application layer
│   └── Services/
│       ├── IStudentService.cs
│       └── StudentService.cs
├── TTShang.Database.Adapter/        # Infrastructure layer
│   ├── Context/
│   │   └── TTShangDbContext.cs
│   └── Repositories/
│       └── StudentRepository.cs
├── TTShang.Web.Core/                # Web configuration
│   └── Startup.cs
└── TTShang.Web.Entry/               # Blazor Server entry
    ├── Components/
    │   ├── Pages/
    │   │   └── Students.razor       # Student CRUD page
    │   └── Layout/
    ├── Program.cs
    └── appsettings.json
```

## Development

### Adding New Entities
1. Create the entity in `TTShang.Core/Entities/`
2. Create the repository interface in `TTShang.Core/Repositories/`
3. Implement the repository in `TTShang.Database.Adapter/Repositories/`
4. Add DbSet to `TTShangDbContext`
5. Create service interface and implementation in `TTShang.Application/Services/`
6. Create Blazor page in `TTShang.Web.Entry/Components/Pages/`

### Dependency Injection
The solution uses Furion's dependency injection attributes:
- `ITransient`: For transient services (new instance per request)
- Services are automatically registered by Furion

## Security Notes

⚠️ **Important**: The default connection string in `appsettings.json` uses hardcoded credentials for development purposes. In production environments, always use:
- Environment variables
- Azure Key Vault
- User secrets
- Or other secure configuration methods

## License

This project is created as part of a demonstration and follows standard open-source practices.
