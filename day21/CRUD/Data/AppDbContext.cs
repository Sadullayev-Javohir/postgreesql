using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Data;

public class AppDbContext : DbContext
{
  public DbSet<Product> Products { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Port=5432;Password=1234;Username=javohir;Database=localdb");
  }

  
}
