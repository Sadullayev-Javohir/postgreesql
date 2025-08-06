using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Username=javohir;Password=1234;Port=5432;Database=localdb");
  }
}
