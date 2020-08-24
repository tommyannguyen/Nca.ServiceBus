using Microsoft.EntityFrameworkCore;
using Multilingual.Abtraction;

namespace Multilingual.Repositories
{
    public class MultilingualDbContext : DbContext
    {
        public MultilingualDbContext() { }
        public MultilingualDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<MultilingualString> MultilingualStrings { get; set; }
    }
}
