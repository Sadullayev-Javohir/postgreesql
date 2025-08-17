using Microsoft.EntityFrameworkCore;
using One.Models;

namespace One.Data;

public class AppDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<UserProfile> UserProfiles { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Host=localhost;Username=javohir;Database=localdb;Password=1234;Port=5432");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>()
    .HasOne(u => u.UserProfile)
    .WithOne(up => up.User)
    .HasForeignKey<UserProfile>(up => up.UserId)
    .IsRequired();
  }
}
