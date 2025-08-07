using Microsoft.EntityFrameworkCore;
using BlogApp.Models;

namespace BlogApp.Data;

public class AppDbContext : DbContext
{
  public DbSet<BlogPost> BlogPosts => Set<BlogPost>();
  public DbSet<Comment> Comments => Set<Comment>();

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Username=javohir;Port=5432;Password=1234;Database=localdb");
  }
}

