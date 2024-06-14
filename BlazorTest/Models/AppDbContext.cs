using Microsoft.EntityFrameworkCore;

namespace BlazorTest.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=TestDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

    }
}
