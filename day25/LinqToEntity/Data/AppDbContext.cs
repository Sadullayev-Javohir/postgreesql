using Microsoft.EntityFrameworkCore;
using LinqToEntity.Models;

namespace LinqToEntity.Data;

public class AppDbContext : DbContext
{
  public DbSet<Product> Products { get; set; }
  public DbSet<Category> Categories { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Port=5432;Password=1234;Database=many;Username=javohir;");
  }
}

