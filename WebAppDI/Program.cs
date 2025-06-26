using CasCap;
using CasCap.Controllers;
using CasCap.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add all MVC/API Controllers in the Web Application project itself
builder.Services.AddControllersAsServices(typeof(Program).Assembly.GetExportedTypes()
    .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
    .Where(t => typeof(Microsoft.AspNetCore.Mvc.Controller).IsAssignableFrom(t) 
        || typeof(Microsoft.AspNetCore.Mvc.ControllerBase).IsAssignableFrom(t)
        || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

// Add additional MVC/API Controllers in the external Class Library project
builder.Services.AddTransient<StringsController>();
builder.Services.AddTransient<AboutController>();

// Setup our test DI Service
builder.Services.AddSingleton<IDITestService, DITestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
