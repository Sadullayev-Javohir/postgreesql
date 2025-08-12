using Microsoft.EntityFrameworkCore;
using BlogApp.Models;

namespace BlogApp.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Post> Posts { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Comment> Comments { get; set; }
}
