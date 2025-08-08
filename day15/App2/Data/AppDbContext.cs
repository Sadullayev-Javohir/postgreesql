using Microsoft.EntityFrameworkCore;
using App2.Models;

namespace App2.Data;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }
  public DbSet<Course> Courses { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Password=1234;Port=5432;Database=localdb;Username=javohir");
  }
}
