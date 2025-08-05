using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public DbSet<Product> Products => Set<Product>();

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Port=5432;Username=javohir;Database=localdb;Password=1234");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>().HasData(
      new Product {Id = 1, Name = "Olma", Price = 1600},
      new Product {Id = 2, Name = "Gilos", Price = 2000},
      new Product {Id = 3, Name = "Nok", Price = 3000}
    );
  }
}
