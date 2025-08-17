using Microsoft.EntityFrameworkCore;
using Explicit.Models;

namespace Explicit.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql("Host=localhost;Username=javohir;Password=1234;Port=5432;Database=localdb");
    }
  }
}
