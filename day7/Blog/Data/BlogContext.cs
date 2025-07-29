using Microsoft.EntityFrameworkCore;

using Blog.Models;

namespace Blog.Data
{
  public class BlogContext : DbContext
  {
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=blogdb;Username=postgres;Password=1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
