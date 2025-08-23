using Microsoft.EntityFrameworkCore;
using TransactionDemo.Models;

namespace TransactionDemo.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<User> Users { get; set; }

}
