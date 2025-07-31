using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Data;

using BlogSystem.Models;

public class AppDbContext : DbContext
{
  public DbSet<Post> Posts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=localdb;Username=javohir;Password=1234");
  }
}
