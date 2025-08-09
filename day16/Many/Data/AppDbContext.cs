using Microsoft.EntityFrameworkCore;
using Many.Models;

namespace Many.Data;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }
  public DbSet<Course> Courses { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Username=javohir;Database=many;Port=5432;Password=1234");
  }
}
