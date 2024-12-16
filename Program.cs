using Microsoft.EntityFrameworkCore;  // Required for DbContext
using ERPSystem.Data;      // Replace with your actual namespace

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

// Retrieve the connection string from appsettings.json
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with SQL Server
builder.Services.AddDbContext<ErpsystemContext>(q => q.UseSqlServer(conn));

builder.Services.AddControllersWithViews();

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
