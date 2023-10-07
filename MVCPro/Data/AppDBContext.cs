using Microsoft.EntityFrameworkCore;
using MVCPro.Models;

namespace MVCPro.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Category> categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Test", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Aon", DisplayOrder = 5 }
                );
        }
    }
}
