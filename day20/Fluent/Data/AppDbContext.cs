using Fluent.Models;
using Fluent.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Fluent.Data;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Port=5432;Password=1234;Username=javohir;Database=localdb");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new StudentConfiguration());
  }
}
