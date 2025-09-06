using Microsoft.EntityFrameworkCore;
using MyMvcApp.Models;

namespace MyMvcApp.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Product> Products { get; set; }
  public DbSet<Category> Categories { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Category>().HasData(
      new Category {Id = 1, Name = "Electronics"},
      new Category {Id = 2, Name = "Books"},
      new Category {Id = 3, Name = "Clothing"}
    );

    modelBuilder.Entity<Product>().HasData(
      new Product { Id = 1, Name = "Smartphone", Price = 1199.00m, CategoryId = 1},
      new Product { Id = 2, Name = "MacBook", Price = 2199.00m , CategoryId = 1},
      new Product { Id = 3, Name = "Novel", Price = 39.00m , CategoryId = 2},
      new Product { Id = 4, Name = "T-shirt", Price = 15.00m , CategoryId = 3}
    );
  }
}

