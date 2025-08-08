# ASP.NET Core Web Application (.NET 8) with Dependency Injection

This repository demonstrates how to use dependency injection in an ASP.NET Core web application running on .NET 8. It has been upgraded from the original .NET Framework 4.7.2 version to showcase the modernization path from legacy ASP.NET MVC to ASP.NET Core.

## Migration Summary

This project has been successfully upgraded from:
- **.NET Framework 4.7.2** → **.NET 8**
- **ASP.NET MVC 5** → **ASP.NET Core MVC**
- **ASP.NET Web API 2** → **ASP.NET Core Web API**
- **OWIN Startup** → **ASP.NET Core Startup**
- **MSTest** → **xUnit** (for better .NET Core compatibility)

## Key Changes Made

### Project Structure
- Converted `WebAppDI.csproj` from old-style .NET Framework format to modern SDK-style project
- Updated all projects to target `.NET 8`
- Moved static files from `Content/` and `Scripts/` to `wwwroot/`
- Removed old .NET Framework files (`Global.asax`, `Web.config`, `App_Start/`, etc.)

### Dependency Injection
- Removed custom dependency resolvers (`DefaultDependencyResolverMVC`, `DefaultDependencyResolverAPI`)
- Simplified DI configuration using built-in ASP.NET Core DI container
- Controllers are now automatically registered by the framework

### Controllers
- Updated MVC controllers to inherit from `Microsoft.AspNetCore.Mvc.Controller`
- Updated API controllers to inherit from `Microsoft.AspNetCore.Mvc.ControllerBase`
- Changed return types from `ActionResult` to `IActionResult`
- Updated API routing from `[RoutePrefix]` to `[Route]` attributes

### Views
- Updated Razor views to use ASP.NET Core tag helpers
- Replaced `@Html.ActionLink` with `asp-controller`/`asp-action` tag helpers
- Removed bundling and optimization (replaced with direct script/CSS references)
- Added `_ViewImports.cshtml` for ASP.NET Core

### Testing
- Switched from MSTest to xUnit for better .NET Core compatibility
- Updated test packages to latest versions

## Solution Structure

- **WebAppDI** - ASP.NET Core Web Application (.NET 8) with MVC & Web API controllers
- **WebAppDILib** - .NET 8 class library containing shared services and controllers
- **WebApp.Tests** - .NET 8 test project using xUnit
- **AzurePipelines** - Azure Pipelines YAML build/test pipeline

## Features

The application demonstrates:
- **Dependency Injection**: Services are registered in `Startup.ConfigureServices()` and injected into controllers
- **Logging**: Uses `Microsoft.Extensions.Logging` for structured logging
- **MVC Controllers**: Traditional MVC controllers with views
- **API Controllers**: RESTful API endpoints
- **Cross-Project Dependencies**: Controllers in the class library are registered and used

## API Endpoints

- `GET /api/values/testdi` - Returns integer values from the DI service
- `GET /api/strings/testdi` - Returns string values from the DI service

## MVC Routes

- `/` - Home page displaying DI service data
- `/About` - About page displaying DI service data

## Running the Application

```bash
# Build the solution
dotnet build

# Run tests
dotnet test

# Run the web application
cd WebAppDI
dotnet run
```

## Migration Benefits

This upgrade provides:
- **Performance**: Significant performance improvements with .NET 8
- **Cross-Platform**: Can now run on Windows, Linux, and macOS
- **Modern Framework**: Access to latest ASP.NET Core features
- **Simplified DI**: Built-in dependency injection without custom resolvers
- **Better Tooling**: Improved development experience with modern tooling
- **Long-term Support**: .NET 8 is an LTS release

The migration maintains all original functionality while providing a modern, maintainable codebase ready for future enhancements.

[![Build Status](https://dev.azure.com/f2calv/github/_apis/build/status/f2calv.WebAppDI?branchName=master)](https://dev.azure.com/f2calv/github/_build/latest?definitionId=1&branchName=master)