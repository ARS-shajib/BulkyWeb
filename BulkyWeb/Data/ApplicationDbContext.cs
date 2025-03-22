using BulkyWeb.Models;
/*Microsoft.EntityFrameworkCore: Provides EF Core functionalities.*/
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    /*This class inherits from DbContext, which is a built-in EF Core class.
    It manages the database connection and enables CRUD (Create, Read, Update, Delete) operations.*/
    public class ApplicationDbContext : DbContext
    {
        /*This constructor receives DbContextOptions<ApplicationDbContext>, which is injected at runtime (configured in Program.cs).
        The base(options) passes the configuration to DbContext.*/
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        /*DbSet<Category> represents the Categories table in the database.
        EF Core will map the Category C# model to a Categories table in SQL Server.*/
        public DbSet<Category> Categories { get; set; }
        /*How It Works:
        When you perform operations like context.Categories.Add(), context.SaveChanges(), or context.Categories.ToList(), 
        EF Core translates these into SQL queries for the database.*/
    }
}
