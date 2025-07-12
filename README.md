# ASP.NET Core 8 Web Application with Dependency Injection

This repository demonstrates a fully modernized ASP.NET Core 8 web application that has been upgraded from the legacy .NET Framework 4.7.2.

**🎉 MODERNIZATION COMPLETE**: This application has been successfully upgraded from ASP.NET MVC 5 (.NET Framework 4.7.2) to ASP.NET Core 8 (.NET 8.0)!

## What Was Modernized

### Framework Upgrade
- **From**: .NET Framework 4.7.2 with ASP.NET MVC 5
- **To**: .NET 8.0 with ASP.NET Core 8
- **Benefits**: Better performance, cross-platform support, modern development experience

### Key Changes Made
1. **Project Structure**: Converted from old-style .csproj to modern SDK-style projects
2. **Dependency Injection**: Migrated from custom OWIN-based DI to built-in ASP.NET Core DI
3. **Controllers**: Updated from `System.Web.Mvc.Controller` to `Microsoft.AspNetCore.Mvc.Controller`
4. **API Controllers**: Migrated from Web API 2 to ASP.NET Core Web API
5. **Views**: Updated Razor views to use ASP.NET Core tag helpers and modern patterns
6. **Static Files**: Moved to `wwwroot` folder following ASP.NET Core conventions
7. **Configuration**: Replaced `Startup.cs` OWIN configuration with modern `Program.cs`

### Modern Patterns Implemented
- Built-in dependency injection container
- Tag helpers for cleaner Razor syntax
- Modern routing with attribute routing
- Nullable reference types enabled
- Implicit usings for cleaner code

## Project Structure

This solution consists of:
- **WebAppDI** - ASP.NET Core 8 Web Application with both MVC & Web API controllers
- **WebAppDILib** - .NET 8 class library containing shared controllers and services
- **WebApp.Tests** - .NET 8 test project with unit tests
- **AzurePipelines** - Azure Pipelines YAML build/test pipeline

## Features Demonstrated

### Dependency Injection
The application showcases dependency injection patterns that work seamlessly across:
- MVC Controllers (`HomeController`)
- API Controllers (`ValuesController`, `StringsController`)
- Services (`DITestService` implementing `IDITestService`)
- Logging (`ILogger<T>`)

### Cross-Project Architecture
- Controllers can be defined in separate class libraries
- Services are shared across the entire application
- Dependency injection works consistently across all projects

## API Endpoints

- `GET /api/values/testdi` - Returns integer values from the DI service
- `GET /api/strings/testdi` - Returns string values from the DI service

## Running the Application

```bash
# Build the solution
dotnet build

# Run tests
dotnet test

# Start the web application
dotnet run --project WebAppDI
```

The application will be available at `http://localhost:5000` (or `https://localhost:5001` for HTTPS).

## Migration Benefits

This modernization provides:

1. **Performance**: Significant performance improvements with .NET 8
2. **Cross-Platform**: Can now run on Windows, Linux, and macOS
3. **Modern Tooling**: Access to latest C# features and development tools
4. **Cloud-Ready**: Better suited for containerization and cloud deployment
5. **Long-term Support**: .NET 8 is an LTS release with extended support
6. **Ecosystem**: Access to the rich .NET ecosystem and NuGet packages

## Next Steps

With this modernization complete, you can now:
- Deploy to modern hosting platforms (Azure App Service, containers, etc.)
- Take advantage of .NET 8 performance improvements
- Use modern C# language features
- Integrate with cloud-native services
- Implement modern authentication and authorization patterns

## Build Status

[![Build Status](https://dev.azure.com/f2calv/github/_apis/build/status/f2calv.WebAppDI?branchName=master)](https://dev.azure.com/f2calv/github/_build/latest?definitionId=1&branchName=master)

---

*This project serves as a reference for teams looking to modernize their legacy ASP.NET applications to ASP.NET Core 8.*