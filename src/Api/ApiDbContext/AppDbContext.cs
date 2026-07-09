
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.ApiDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>().HasData(
            new Country { Id = 1, Name = "United States", Code = "US" },
            new Country { Id = 2, Name = "Canada", Code = "CA" },
            new Country { Id = 3, Name = "United Kingdom", Code = "UK" }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = Guid.Parse("67f3b154-5ef9-4acd-ae15-6e04b6db9741"), Name = "John Doe", Position = "Software Engineer", Active = true, CountryId = 1 },
            new Employee { Id = Guid.Parse("67f3b154-5ef9-4acd-ae15-6e04b6db9742"), Name = "Jane Smith", Position = "Project Manager", Active = true, CountryId = 2 },
            new Employee { Id = Guid.Parse("67f3b154-5ef9-4acd-ae15-6e04b6db9743"), Name = "Bob Johnson", Position = "Designer", Active = false, CountryId = 3 },
            new Employee { Id = Guid.Parse("67f3b154-5ef9-4acd-ae15-6e04b6db9744"), Name = "Bob Johnson", Position = "Designer", Active = false, CountryId = 3 }
        );
    }
}