using CasCap;
using CasCap.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(); // For JSON serialization compatibility

// Add API controllers
builder.Services.AddControllers();

// Register custom services
builder.Services.AddSingleton<IDITestService, DITestService>();

// Add controllers from the library project
builder.Services.AddTransient<StringsController>();
builder.Services.AddTransient<AboutController>();

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

// Configure MVC routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configure API routes
app.MapControllers();

app.Run();
