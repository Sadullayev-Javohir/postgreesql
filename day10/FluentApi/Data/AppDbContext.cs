using Microsoft.EntityFrameworkCore;
using FluentApi.Models;
using FluentApi.Configurations;

namespace FluentApi.Data;

public class AppDbContext : DbContext
{
  public DbSet<Student> Students { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseNpgsql("Username=javohir;Port=5432;Password=1234;Database=localdb;Host=localhost");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new StudentConfiguration());
  }

}
