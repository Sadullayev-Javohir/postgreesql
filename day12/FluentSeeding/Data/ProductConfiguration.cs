using FluentSeeding.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentSeeding.Data;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.ToTable("Products");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Title)
    .IsRequired()
    .HasMaxLength(100);

    builder.Property(p => p.Cost)
    .HasColumnType("decimal(18,2)");

    builder.Property(p => p.InStock)
    .HasDefaultValue(true);

    builder.HasData(
      new Product { Id = 1, Title = "Stol kompyuteri", Cost = 7200000, InStock = true },
      new Product { Id = 2, Title = "Smartfon", Cost = 4500000, InStock = true },
      new Product { Id = 3, Title = "Quvvatlagich", Cost = 90000, InStock = false }
    );
  }
}
