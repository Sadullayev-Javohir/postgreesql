using Microsoft.EntityFrameworkCore;
using EFCoreConcurrencyDemo.Models;

namespace EFCoreConcurrencyDemo.Data;

public class AppDbContext : DbContext
{
  public DbSet<Product> Products { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Username=javohir;Database=concurrencydb;Password=1234");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>()
      .Property(p => p.RowVersion)
      .IsRowVersion()
      .HasColumnName("xmin")
      .HasColumnType("xid")
      .ValueGeneratedOnAddOrUpdate();

    base.OnModelCreating(modelBuilder);
  }
}
