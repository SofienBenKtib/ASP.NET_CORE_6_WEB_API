using Microsoft.EntityFrameworkCore;

namespace ProductWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Database Context Dependency Injection
            var dbHost = "localhost";
            var dbName = "dms_product";
            var dbPassword = "";

            var connectionString = $"server={dbHost};port=3306;database={dbName};user=root;password={dbPassword}";
            builder.Services.AddDbContext<ProductDbContext>(o => o.UseMySQL(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}