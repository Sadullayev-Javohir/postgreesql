using Microsoft.EntityFrameworkCore;
using Seeding.Models;

namespace Seeding.Data;

public class ApplicationDbContext : DbContext
{
  public DbSet<Product> Products { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Port=5432;Database=localdb;Password=1234;Username=javohir");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>().HasData(
      new Product { Id = 1, Name = "Thinkpad", Price = 1230m },
      new Product { Id = 2, Name = "apple", Price = 1m },
      new Product { Id = 3, Name = "HairDryer", Price = 123m }
    );
  }
}
