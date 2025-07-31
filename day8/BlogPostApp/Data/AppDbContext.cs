using Microsoft.EntityFrameworkCore;
using BlogPostApp.Models;

namespace BlogPostApp.Data;

public class AppDbContext : DbContext
{
  public DbSet<Post> Postss { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=localdb;Username=javohir;Password=1234");
  }
}
