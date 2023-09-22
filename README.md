 # Movie Api

## Technologies
* [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Entity Framework Core 6](https://docs.microsoft.com/en-us/ef/core/)
* [JWT Bearer]
* [Api_Key]
* [FluentValidation](https://fluentvalidation.net/)
* [Middleware]
* [CORS]
* [DepedencyInjection]
* [UnitOfWorks]
* [UnitTest X]

## Getting Started

Install the [NuGet package](https://www.nuget.org/packages/Matech.Clean.Architecture.Template) and run `dotnet new cas`:

1. Install the latest [.NET SDK](https://dotnet.microsoft.com/download)
2. Run `dotnet new --install Matech.Clean.Architecture.Template` to install the project template
3. Create a folder for your solution and cd into it (the template will use it as project name)
4. Run `dotnet new cas` to create a new project
5. Navigate to `src/Apps/CleanArchitecture.Api` and run `dotnet run` to launch the back end (ASP.NET Core Web API)
6. Open web browser https://localhost:5021/api Swagger UI


### Database Configuration

The template is configured to use an in-memory database by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

```json
  "DefaultConnection": Npgsql
```
`DbProvider` could be `Npgsql` by default, which could be extended to more database providers that EF Core supports. 

Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid PostgresSQL instance.

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

### Database Migrations

Pelase run query on , file Database MovieDb.Txt :

### TestBackendOnPostman

Please import to yout postman application, we put the potman collection on Movie_Api.postman_collection.JSON

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Api_Movie

This layer is a web api application based on ASP.NET 6.0.x. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.


