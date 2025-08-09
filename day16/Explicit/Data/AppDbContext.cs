using Microsoft.EntityFrameworkCore;
using Explicit.Models;

namespace Explicit.Data;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }
  public DbSet<Course> Courses { get; set; }
  public DbSet<StudentCourse> StudentCourses { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Database=many1;Password=1234;Port=5432;Username=javohir");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<StudentCourse>()
      .HasKey(sc => new { sc.StudentId, sc.CourseId });

    modelBuilder.Entity<StudentCourse>()
      .HasOne(sc => sc.Student)
      .WithMany(s => s.StudentCourses)
      .HasForeignKey(sc => sc.StudentId);

    modelBuilder.Entity<StudentCourse>()
      .HasOne(sc => sc.Course)
      .WithMany(c => c.StudentCourses)
      .HasForeignKey(sc => sc.CourseId);
  }
}
