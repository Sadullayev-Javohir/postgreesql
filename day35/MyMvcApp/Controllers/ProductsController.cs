using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Data;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class ProductsController : Controller
{
  private readonly AppDbContext _context;
  public ProductsController(AppDbContext context) => _context = context;

  public async Task<IActionResult> Index()
  {
    using (MiniProfiler.Current.Step("Load products"))
    {
      var products = await _context.Products.Include(p => p.Category).ToListAsync();
      return View(products);
    }
  }

}
