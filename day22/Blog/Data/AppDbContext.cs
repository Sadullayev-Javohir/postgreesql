using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Data;

public class AppDbContext : DbContext
{
  public DbSet<BlogPost> BlogPosts { get; set; }
  public DbSet<Comment> Comments { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Port=5432;Password=1234;Username=javohir;Database=localdb");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Comment>()
      .HasOne(c => c.BlogPost)
      .WithMany(b => b.Comments)
      .HasForeignKey(c => c.BlogPostId);
  }

}
