using Gestion_Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura los servicios de la aplicación.
builder.Services.AddControllersWithViews();

// Configura Entity Framework con SQL Server.
builder.Services.AddDbContext<GBContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("GBContext")));

var app = builder.Build();

// Configura el middleware.
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
    pattern: "{controller=Libros}/{action=Index}/{id?}");

app.Run();
