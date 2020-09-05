using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Multilingual.MigrationTool
{

    /// <summary>
    /// dotnet ef migrations add InitialCreate
    /// dotnet ef database update
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Start Migrate World!");
            waitForDb();
            Console.WriteLine("Hello Migrate World!");
        }

        private static void waitForDb()
        {
            var maxAttemps = 12;
            for (int i = 0; i < maxAttemps; i++)
            {
                try
                {
                    var app = new AppDbContext();

                    app.Database.Migrate();
                    return;
                }
                catch( Exception ex)
                {
                    Console.WriteLine($"Wait Migrate World! {i} {ex.Message}");
                    Thread.Sleep(20000);
                }
               
               
            }

        }

    }
}
