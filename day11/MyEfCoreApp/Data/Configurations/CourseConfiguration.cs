using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEfCoreApp.Models;

namespace MyEfCoreApp.Data.Configurations
{
  public class CourseConfiguration : IEntityTypeConfiguration<Course>
  {
    public void Configure(EntityTypeBuilder<Course> builder)
    {
      builder.ToTable("courses");

      builder.HasKey(c => c.Id);

      builder.Property(c => c.Title)
             .IsRequired()
             .HasMaxLength(200);

      builder.HasOne(c => c.Student)
             .WithMany(s => s.Courses)
             .HasForeignKey(c => c.StudentId);

      builder.HasData(
          new Course
          {
            Id = 1,
            Title = "Matematika",
            StudentId = 1
          },
          new Course
          {
            Id = 2,
            Title = "Fizika",
            StudentId = 2
          }
      );
    }
  }
}
