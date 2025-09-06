using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
  public ApplicationDbContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=javohir;Password=1234;Database=localdb");

    var context = new ApplicationDbContext(optionsBuilder.Options);
    context.SetTenantId(1); // migrations uchun default
    return context;
  }
}
