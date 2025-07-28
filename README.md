# ASP.NET Core Web Application (.NET 8) with Dependency Injection

This repository demonstrates how to use dependency injection in an ASP.NET Core 8 web application. It has been modernized from the original .NET Framework 4.7.2 version to showcase the migration path to modern .NET.

This solution serves as an example for developers looking to migrate their legacy ASP.NET MVC applications to ASP.NET Core 8, demonstrating how dependency injection works seamlessly in the modern framework.

The repository shows how to:
- Use built-in dependency injection in ASP.NET Core 8
- Structure controllers in both the main web application and external class libraries
- Implement both MVC and Web API controllers with dependency injection
- Set up logging using the modern Microsoft.Extensions.Logging framework

This solution was built using Visual Studio and consists of:
- **WebAppDI** - ASP.NET Core 8 Web Application utilizing both MVC & Web API controllers
- **WebAppDILib** - .NET 8 class library containing additional controllers and services
- **WebApp.Tests** - .NET 8 class library for unit tests
- **AzurePipelines** - example [Azure Pipelines YAML build/test](https://docs.microsoft.com/en-us/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema) pipeline

## Migration Changes Made

The application has been successfully migrated from .NET Framework 4.7.2 to .NET 8 with the following key changes:

### Project Structure Updates
- Converted from old-style .csproj to modern SDK-style project files
- Updated all projects to target .NET 8
- Removed legacy configuration files (web.config, Global.asax, etc.)
- Added modern configuration files (appsettings.json, appsettings.Development.json)

### Framework Migration
- Migrated from ASP.NET MVC 5 to ASP.NET Core 8 MVC
- Migrated from ASP.NET Web API 2 to ASP.NET Core 8 Web API
- Updated from OWIN/Katana to ASP.NET Core's built-in hosting model
- Replaced custom dependency resolvers with ASP.NET Core's built-in DI container

### Code Updates
- Updated controllers to use `Microsoft.AspNetCore.Mvc` instead of `System.Web.Mvc`
- Changed `ActionResult` to `IActionResult` for better async support
- Updated Web API controllers to inherit from `ControllerBase` instead of `ApiController`
- Modernized routing with attribute-based routing
- Updated views to use ASP.NET Core Razor syntax
- Added nullable reference types support

### Dependency Injection Simplification
The original complex dependency injection setup with custom resolvers has been replaced with ASP.NET Core's built-in DI container, making the code much simpler and more maintainable.

## Key Features

- **Built-in Dependency Injection**: Uses ASP.NET Core's native DI container
- **Modern Logging**: Utilizes Microsoft.Extensions.Logging for structured logging
- **Cross-Project Controllers**: Demonstrates how to use controllers from external class libraries
- **Mixed MVC/API**: Shows both traditional MVC views and Web API endpoints in the same application
- **Unit Testing**: Includes example unit tests using MSTest framework

## Running the Application

```bash
# Build the solution
dotnet build

# Run tests
dotnet test

# Run the web application
dotnet run --project WebAppDI
```

The application will be available at `https://localhost:5001` (HTTPS) or `http://localhost:5000` (HTTP).

## API Endpoints

- `GET /api/values/testdi` - Returns integer values from the DI test service
- `GET /api/strings/testdi` - Returns string values from the DI test service

## MVC Routes

- `/` or `/Home` - Home page displaying DI test data
- `/About` - About page displaying DI test data from the class library controller

This modernized version demonstrates how legacy ASP.NET applications can be successfully migrated to ASP.NET Core 8 while maintaining functionality and improving maintainability.

[![Build Status](https://dev.azure.com/f2calv/github/_apis/build/status/f2calv.WebAppDI?branchName=master)](https://dev.azure.com/f2calv/github/_build/latest?definitionId=1&branchName=master)