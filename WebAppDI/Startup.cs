using CasCap.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CasCap
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC services
            services.AddControllersWithViews();
            
            // Add API controllers
            services.AddControllers();

            // Add controllers from the library project
            services.AddTransient<StringsController>();
            services.AddTransient<AboutController>();
            
            // Setup our test DI Service
            services.AddSingleton<IDITestService, DITestService>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Configure MVC routes
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Configure API routes
            app.MapControllers();
        }
    }
}