using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEfCoreApp.Models;
using System;

namespace MyEfCoreApp.Data.Configurations
{
  public class StudentConfiguration : IEntityTypeConfiguration<Student>
  {
    public void Configure(EntityTypeBuilder<Student> builder)
    {
      builder.ToTable("students");

      builder.HasKey(s => s.Id);

      builder.Property(s => s.FullName)
            .IsRequired()
            .HasMaxLength(100);
      builder.HasData(
          new Student
          {
            Id = 1,
            FullName = "Ali Valiyev",

          },
          new Student
          {
            Id = 2,
            FullName = "Shahnoza Karimova",

          }
      );
    }
  }
}
