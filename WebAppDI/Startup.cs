using CasCap.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace CasCap
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add controllers from external library
            services.AddTransient<StringsController>();
            services.AddTransient<AboutController>();
            
            // Setup our test DI Service
            services.AddSingleton<IDITestService, DITestService>();
        }
    }
}