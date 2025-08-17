using Lazy.Models;
using Microsoft.EntityFrameworkCore;

namespace Lazy.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // User (1) ---- (∞) Post
      modelBuilder.Entity<User>()
          .HasMany(u => u.Posts)
          .WithOne(p => p.User)
          .HasForeignKey(p => p.UserId)
          .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
