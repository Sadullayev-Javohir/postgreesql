using Microsoft.EntityFrameworkCore;
using EfMigrationDemo.Models;

namespace EfMigrationDemo.Data;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=student;Username=javohir;Password=1234");
  }
}
