using CasCap.Controllers;
using CasCap.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CasCap
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC services
            services.AddControllersWithViews();
            services.AddControllers();

            // Add all MVC/API Controllers in the Web Application project itself
            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
              .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
              .Where(t => typeof(ControllerBase).IsAssignableFrom(t) || typeof(Controller).IsAssignableFrom(t)));

            // Add additional MVC/API Controllers in the external Class Library project
            services.AddTransient<StringsController>();
            services.AddTransient<AboutController>();
            
            // Setup Logging
            services.AddLogging();

            // Setup our test DI Service
            services.AddSingleton<IDITestService, DITestService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapControllers(); // For API controllers
            });
        }
    }
}