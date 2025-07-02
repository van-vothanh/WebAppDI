using CasCap.Controllers;
using CasCap.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CasCap
{
    public partial class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add controllers from the current assembly
            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
              .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
              .Where(t => t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

            // Add additional controllers from the external Class Library project
            services.AddTransient<StringsController>();
            services.AddTransient<AboutController>();
            
            // Setup Logging (ASP.NET Core provides this by default, but we can configure it)
            services.AddLogging();

            // Setup our test DI Service
            services.AddSingleton<IDITestService, DITestService>();
        }
    }
}