using CRUD_ASP.NET_MVC_ADO.NET.Models;
using CRUD_ASP.NET_MVC_ADO.NET.Repositories.Contract;
using CRUD_ASP.NET_MVC_ADO.NET.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IGenericRepository<Departamento>, DepartamentoRepository>();
builder.Services.AddScoped<IGenericRepository<Empleado>, EmpleadoRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// https://youtu.be/Pb6Ohi9OQzU?t=2571