using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Multilingual.MockDb;
namespace Multilingual.MigrationTool
{
    public class AppDbContext : MockDbContext
    {
        public AppDbContext() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=mockDb;User=root;Password=123456a@A");
            base.OnConfiguring(optionsBuilder);
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty;
                    IConfigurationRoot configuration = new ConfigurationBuilder()
                     .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                     .AddJsonFile("appsettings.json")
                     .AddJsonFile($"appsettings.{env}.json", optional: true)
                     .Build();

                    services.AddHlkCloudMigration(configuration);
                });
    }
}
