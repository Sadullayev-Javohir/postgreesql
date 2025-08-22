using Microsoft.EntityFrameworkCore;
using App.Models;
using App.Data;

namespace App.Repositories;

public class ProductRepository
{
  private readonly AppDbContext _context;

  public ProductRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<List<Product>> GetAllAsync()
  {
    return await _context.Products.ToListAsync();
  }

  public async Task AddAsync(Product product)
  {
    await _context.Products.AddAsync(product);
    await _context.SaveChangesAsync();
  }
}
