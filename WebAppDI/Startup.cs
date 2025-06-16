using CasCap.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace CasCap
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureCustomServices(this IServiceCollection services)
        {
            // Add controllers from the external Class Library project
            services.AddTransient<StringsController>();
            services.AddTransient<AboutController>();
            
            // Setup our test DI Service
            services.AddSingleton<IDITestService, DITestService>();

            return services;
        }
    }
}