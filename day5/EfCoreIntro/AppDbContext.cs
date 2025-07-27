using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
  public DbSet<Blog> Blogs { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EfCoreBlogDb;Username=postgres;Password=1234");
  }
}
