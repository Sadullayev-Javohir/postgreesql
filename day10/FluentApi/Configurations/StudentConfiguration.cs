using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FluentApi.Models;

namespace FluentApi.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
  public void Configure(EntityTypeBuilder<Student> builder)
  {
    builder.ToTable("Students");

    builder.HasKey(s => s.Id);

    builder.Property(s => s.FullName)
    .HasMaxLength(100)
    .IsRequired();

    builder.Property(s => s.Email)
    .HasMaxLength(150)
    .IsRequired();

    builder.Property(s => s.BirthDate)
    .HasColumnType("date");
  }
}
