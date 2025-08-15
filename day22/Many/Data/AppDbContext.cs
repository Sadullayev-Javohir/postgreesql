using Microsoft.EntityFrameworkCore;
using Many.Models;

namespace Many.Data;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }
  public DbSet<Course> Courses { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Username=javohir;Port=5432;Password=1234;Database=localdb");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Student>()
    .HasMany(s => s.Courses)
    .WithMany(c => c.Students)
    .UsingEntity<Dictionary<string, object>>(
        "StudentCourse",
        j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
        j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId")
    );

  }
}
