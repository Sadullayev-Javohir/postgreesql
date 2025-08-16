using Microsoft.EntityFrameworkCore;
using Many.Models;

namespace Many.Data;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }
  public DbSet<Course> Courses { get; set; }
  public DbSet<StudentCourse> StudentCourses { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Database=localdb;Username=javohir;Port=5432;Password=1234");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<StudentCourse>()
      .HasKey(sc => new { sc.StudentId, sc.CourseId });

    modelBuilder.Entity<StudentCourse>()
      .HasOne(sc => sc.Student)
      .WithMany(s => s.StudentCourses)
      .HasForeignKey(sc => sc.StudentId);

    modelBuilder.Entity<StudentCourse>
    ()
      .HasOne(sc => sc.Course)
      .WithMany(s => s.StudentCourses)
      .HasForeignKey(sc => sc.CourseId);
  }
}

