using Microsoft.EntityFrameworkCore;
using TransactionApp.Models;

namespace TransactionApp.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

  public DbSet<User> Users { get; set; }
}
