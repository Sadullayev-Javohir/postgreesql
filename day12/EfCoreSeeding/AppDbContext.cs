using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public DbSet<Product> Products => Set<Product>();

  protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql("Host=localhost; Username=javohir;Password=1234;Database=localdb");

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>().HasData(
      new Product { Id = 1, Name = "Olma", Price = 1000 },
      new Product { Id = 2, Name = "Banan", Price = 1600 },
      new Product { Id = 3, Name = "Uzum", Price = 3566 }
    );
  }
}
