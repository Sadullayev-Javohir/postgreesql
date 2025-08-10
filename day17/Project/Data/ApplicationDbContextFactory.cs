using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Project.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
  public ApplicationDbContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

    // PostgreSQL connection stringni o'zingizga moslang:
    optionsBuilder.UseNpgsql("Host=localhost;Database=loading;Username=javohir;Password=1234");

    return new ApplicationDbContext(optionsBuilder.Options);
  }
}
