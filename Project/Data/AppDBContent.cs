using Microsoft.EntityFrameworkCore;
using Project.Data.Models;
using Project.Models;

namespace Project.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent()
        {
        }

        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
