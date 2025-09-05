using Microsoft.EntityFrameworkCore;
using ConcurrencyExe.Models;

namespace ConcurrencyExe.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Product> Products { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    modelBuilder.Entity<Product>()
      .Property(p => p.xmin)
      .HasColumnName("xmin")
      .IsRowVersion()
      .ValueGeneratedOnAddOrUpdate()
      .Metadata.SetAfterSaveBehavior(
        Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore
      )
      ;

    modelBuilder.Entity<Product>().HasData(
      new Product { Id = 1, Name = "Mac", Price = 1200 },
      new Product { Id = 2, Name = "Iphone", Price = 100 },
      new Product { Id = 3, Name = "Keyboard", Price = 1200 }
    );
  }
}
