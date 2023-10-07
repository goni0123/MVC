using Microsoft.EntityFrameworkCore;
using MVCPro.Models;

namespace MVCPro.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        DbSet<Category> categories { get; set; }
    }
}
