using Microsoft.EntityFrameworkCore;
using ECommerceApp.Models;

namespace ECommerceApp.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Product> Products { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Order> Orders { get; set; }
  public DbSet<OrderItem> OrderItems { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Category>()
    .HasMany(c => c.Products)
    .WithOne(p => p.Category)
    .HasForeignKey(p => p.CategoryId);

    modelBuilder.Entity<Order>()
      .HasMany(o => o.Items)
      .WithOne(oi => oi.Order)
      .HasForeignKey(oi => oi.OrderId);

    modelBuilder.Entity<Product>()
      .HasMany<OrderItem>()
      .WithOne(oi => oi.Product)
      .HasForeignKey(oi => oi.ProductId);
  }
}
