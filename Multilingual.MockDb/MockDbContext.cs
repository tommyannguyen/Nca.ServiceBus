using Microsoft.EntityFrameworkCore;
using Multilingual.MockDb.Models;

namespace Multilingual.MockDb
{
    public class MockDbContext : DbContext
    {
        public MockDbContext() { }
        public MockDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
