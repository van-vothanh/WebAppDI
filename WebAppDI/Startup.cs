using CasCap.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CasCap
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC and API controllers
            services.AddControllersWithViews();
            
            // Add controllers from the external library
            services.AddTransient<StringsController>();
            services.AddTransient<AboutController>();
            
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
                endpoints.MapControllers();
            });
        }
    }
}