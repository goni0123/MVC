using Microsoft.EntityFrameworkCore;
using WebRazor_Temp.Models;

namespace WebRazor_Temp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
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
