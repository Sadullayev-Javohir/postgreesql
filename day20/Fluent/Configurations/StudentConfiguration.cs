using Fluent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fluent.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
  public void Configure(EntityTypeBuilder<Student> builder)
  {
    builder.ToTable("Students");

    builder.HasKey(s => s.Id);

    builder.Property(s => s.FullName)
      .IsRequired()
      .HasMaxLength(100);

    builder.Property(s => s.Age)
      .IsRequired();

    builder.Property(s => s.Email)
      .HasMaxLength(150);

    builder.HasIndex(s => s.Email)
      .IsUnique();
  }
}
