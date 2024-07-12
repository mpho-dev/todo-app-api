using Microsoft.EntityFrameworkCore;
using TodoAPI.Model;
namespace TodoAPI
{
    public class TODODbContext : DbContext
    {
        public DbSet<TODOItem> Items { get; set; }

        public TODODbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
