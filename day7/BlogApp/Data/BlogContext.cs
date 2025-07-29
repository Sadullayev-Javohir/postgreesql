using Microsoft.EntityFrameworkCore;
using BlogApp.Models;

namespace BlogApp.Data
{
  public class BlogContext : DbContext
  {
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql("Port=5432;Host=localhost;Database=blogger;Username=postgres;Password=1234");
    }
  }
}
