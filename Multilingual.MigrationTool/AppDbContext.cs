using Microsoft.EntityFrameworkCore;
using Multilingual.Repositories;

namespace Multilingual.MigrationTool
{
    public class AppDbContext : MultilingualDbContext
    {
        public AppDbContext() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=testDb;User=root;Password=123456a@A");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
