using ConcurrencyD.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyD.Data;

public class AppDbContext : DbContext
{
  public DbSet<Product> Products { get; set; }

  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>()
      .Property(p => p.Xmin)
      .IsRowVersion()
      .HasColumnName("xmin");

    modelBuilder.Entity<Product>().HasData(
      new Product { Id = 1, Name = "Keyboard", Price = 25.50m },
      new Product { Id = 2, Name = "Mouse", Price = 15.20m }
    );
  }


}
