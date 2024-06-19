using Microsoft.EntityFrameworkCore;

namespace BlazorTest.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Color).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Category).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Price).HasPrecision(10, 2);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
