using Microsoft.EntityFrameworkCore;
using ECommerceApp.Models;

public class AppDbContext : DbContext
{
  public DbSet<Product> Products { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql("Username=postgres;Password=1234;Database=product;Host=localhost;Port=5432");
  }
}
