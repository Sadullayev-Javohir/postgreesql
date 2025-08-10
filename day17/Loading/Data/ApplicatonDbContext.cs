using Loading.Models;
using Microsoft.EntityFrameworkCore;

namespace Loading.Data;

public class ApplicationDbContext : DbContext
{
  public DbSet<Author> Authors { get; set; }
  public DbSet<Book> Books { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Port=5432;Username=javohir;Password=1234;Database=loading");
  }
}
