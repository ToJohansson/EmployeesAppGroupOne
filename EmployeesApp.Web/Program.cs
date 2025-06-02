using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Infrastructure.Persistance.Repositories;
using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Web.Models;
using EmployeesApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();

        var connString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(connString));

        builder.Services.AddScoped<MyLogServiceFilterAttribute>();
        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}