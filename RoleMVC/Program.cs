//referencia para las cookies
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//configuracion de las cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        //direccion de la pagina principal
        options.LoginPath = "/Acceso/Index";
        //tiempo dentro de la aplicacion
        options.ExpireTimeSpan= TimeSpan.FromMinutes(1);
        //direccion de acceso denegado
        options.AccessDeniedPath = "/Home/Privacy";
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
//no pueden faltar estos midelwears
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Index}/{id?}");

app.Run();
