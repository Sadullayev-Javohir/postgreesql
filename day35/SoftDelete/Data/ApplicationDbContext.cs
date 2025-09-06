using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
  public DbSet<Product> Products { get; set; }

  public int TenantId { get; private set; }

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
  {
  }

  // Runtime da tenantId set qilinadi
  public void SetTenantId(int tenantId)
  {
    TenantId = tenantId;
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>()
        .HasQueryFilter(p => p.TenantId == TenantId && !p.IsDeleted);
  }
}
