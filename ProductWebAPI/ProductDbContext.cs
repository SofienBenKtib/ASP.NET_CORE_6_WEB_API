using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProductWebAPI.Models;

namespace ProductWebAPI
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null) 
                {
                    //Create database if cannot connect
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();

                    //Create tables if no tables exist
                    if(!databaseCreator.HasTables()) databaseCreator.CreateTables();

                }
            }
            catch
            (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
    }
}
