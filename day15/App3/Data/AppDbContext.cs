using Microsoft.EntityFrameworkCore;
using App3.Models;

namespace App3.Data;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }
  public DbSet<Course> Courses { get; set; }
  public DbSet<StudentCourse> StudentCourses { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Username=javohir;Password=1234;Port=5432;Database=localdb");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Composite Primary Key
    modelBuilder.Entity<StudentCourse>()
      .HasKey(sc => new { sc.StudentId, sc.CourseId });

    // Student -> StudentCourse
    modelBuilder.Entity<StudentCourse>()
      .HasOne(sc => sc.Student)
      .WithMany(s => s.StudentCourses)
      .HasForeignKey(sc => sc.StudentId);

    // Course -> StudentCourse
    modelBuilder.Entity<StudentCourse>()
      .HasOne(sc => sc.Course)
      .WithMany(c => c.StudentCourses)
      .HasForeignKey(sc => sc.CourseId);
  }
}

