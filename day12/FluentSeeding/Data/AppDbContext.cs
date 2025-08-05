using FluentSeeding.Data;
using Microsoft.EntityFrameworkCore;
using FluentSeeding.Models;

public class AppDbContext : DbContext
{
  public DbSet<Product> Products => Set<Product>();

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Port=5432;Username=javohir;Database=localdb;Password=1234");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new ProductConfiguration());
  }
}
