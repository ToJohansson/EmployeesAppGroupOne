using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeesApp.Infrastructure.Persistance;
public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{

    public DbSet<Employee> Employees { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>().HasData(
        new Employee { Id = 1, Name = "Ica", Email = "Stockholm@hotmail.com" },
            new Employee { Id = 22, Name = "Coop", Email = "Stockholm@hotmail.com" },
            new Employee { Id = 3, Name = "Hemköp", Email = "Göteborg@hotmail.com" }
        );
        modelBuilder.Entity<Employee>()
        .Property(e => e.Salary)
        .HasColumnType("money");
    }

}
