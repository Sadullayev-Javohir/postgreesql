using Microsoft.EntityFrameworkCore;
using MigrationMain.Models;

namespace MigrationMain.Data;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Port=5432;Username=javohir;Database=hey;Password=1234");
  }
}
