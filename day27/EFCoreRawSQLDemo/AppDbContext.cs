using Microsoft.EntityFrameworkCore;
using EfCoreRawSQLDemo.Models;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Port=5432;Password=1234;Database=raw;Username=javohir");
  }
}
