# ASP.NET Core Web Application (.NET 8) with Dependency Injection

This repository demonstrates how to use dependency injection in an ASP.NET Core 8 web application, serving as an example for developers migrating from traditional ASP.NET Framework applications to modern ASP.NET Core.

**Note: This project has been successfully migrated from .NET Framework 4.7.2 to .NET 8 with ASP.NET Core.**

.NET Core and ASP.NET Core use dependency injection throughout as a fundamental principle. This repository serves as a working example of how dependency injection and logging work in a modern .NET 8 application using the built-in [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/) and [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging/) packages.

This solution consists of:
- **WebAppDI** - ASP.NET Core 8 Web Application with both MVC & Web API controllers
- **WebAppDILib** - .NET 8 class library containing additional controllers and services
- **WebApp.Tests** - .NET 8 class library for unit tests
- **AzurePipelines** - example [Azure Pipelines YAML build/test](https://docs.microsoft.com/en-us/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema) pipeline

## Key Changes Made During Migration

### Framework Migration
- Upgraded from .NET Framework 4.7.2 to .NET 8
- Migrated from ASP.NET MVC 5 to ASP.NET Core 8
- Replaced OWIN startup with ASP.NET Core Program.cs
- Updated project files to use modern SDK-style format

### Dependency Injection Updates
- Removed custom dependency resolvers (no longer needed in ASP.NET Core)
- Simplified service registration using built-in ASP.NET Core DI container
- Updated controller registration to use ASP.NET Core's automatic controller discovery

### Controller Updates
- Updated MVC controllers to use `Microsoft.AspNetCore.Mvc.Controller`
- Updated API controllers to use `Microsoft.AspNetCore.Mvc.ControllerBase`
- Replaced `ActionResult` with `IActionResult`
- Updated routing attributes for ASP.NET Core conventions

### View and Static File Updates
- Moved static files to `wwwroot` folder
- Replaced bundling with direct file references
- Updated Razor views to use ASP.NET Core tag helpers
- Created `_ViewImports.cshtml` for global using statements

### Configuration Updates
- Replaced `web.config` with `appsettings.json`
- Updated logging configuration for ASP.NET Core
- Removed obsolete configuration files

## Project Structure

The dependency injection configuration is now handled in `Program.cs` where services are registered:

```csharp
// Add controllers from the library project
builder.Services.AddTransient<StringsController>();
builder.Services.AddTransient<AboutController>();

// Setup our test DI Service
builder.Services.AddSingleton<IDITestService, DITestService>();
```

## Building and Running

To build the solution:
```bash
dotnet build
```

To run tests:
```bash
dotnet test
```

To run the web application:
```bash
cd WebAppDI
dotnet run
```

## API Endpoints

The application provides the following API endpoints:
- `GET /api/values/testdi` - Returns integer values from the DI service
- `GET /api/strings/testdi` - Returns string values from the DI service

## MVC Routes

- `/` - Home page displaying DI service data
- `/About` - About page displaying DI service data from library controller

This modernized application demonstrates best practices for dependency injection in ASP.NET Core 8 and serves as a foundation for further development with modern .NET technologies.

[![Build Status](https://dev.azure.com/f2calv/github/_apis/build/status/f2calv.WebAppDI?branchName=master)](https://dev.azure.com/f2calv/github/_build/latest?definitionId=1&branchName=master)