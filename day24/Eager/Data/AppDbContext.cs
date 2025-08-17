using Microsoft.EntityFrameworkCore;
using Eager.Models;

namespace Eager.Data;

public class AppDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<UserProfile> UserProfiles { get; set; }
  public DbSet<Post> Posts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Username=javohir;Password=1234;Port=5432;Database=localdb");
  }
}

