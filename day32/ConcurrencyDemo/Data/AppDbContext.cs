using ConcurrencyDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyDemo.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<Product> Products => Set<Product>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // PostgreSQL system column: xmin -> optimistic concurrency
      modelBuilder.Entity<Product>()
          .Property(p => p.Xmin)
          .IsRowVersion()              // EFga bu concurrency token ekanini bildiradi
          .HasColumnName("xmin");      // Postgres system column nomi

      // Demo uchun seed (ixtiyoriy)
      modelBuilder.Entity<Product>().HasData(
          new Product { Id = 1, Name = "Keyboard", Price = 25.50m },
          new Product { Id = 2, Name = "Mouse", Price = 15.00m }
      );

      base.OnModelCreating(modelBuilder);
    }
  }
}
