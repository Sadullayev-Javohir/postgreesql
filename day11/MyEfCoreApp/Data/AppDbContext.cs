using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Models;
using MyEfCoreApp.Data.Configurations;

namespace MyEfCoreApp.Data;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }
  public DbSet<Student> Courses { get; set; }

  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new StudentConfiguration());
    modelBuilder.ApplyConfiguration(new CourseConfiguration());
  }
}
