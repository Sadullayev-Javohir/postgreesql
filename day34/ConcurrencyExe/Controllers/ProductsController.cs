using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ConcurrencyExe.Data;
using ConcurrencyExe.Models;


namespace ConcurrencyExe;

public class ProductsController : Controller
{
  private readonly AppDbContext _context;
  public ProductsController(AppDbContext context) => _context = context;

  public async Task<IActionResult> Index()
  {
    var products = await _context.Products.ToListAsync();
    return View(products);
  }

  [HttpGet]
  public async Task<IActionResult> Edit(int id)
  {
    var product = await _context.Products.FindAsync(id);
    if (product == null) return NotFound();
    return View(product);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(int? id, Product product)
  {
    if (product.Id != id) return NotFound();
    try
    {
      _context.Update(product);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
    catch (DbUpdateConcurrencyException ex)
    {
      var entry = ex.Entries.Single();

      var databaseEntry = await entry.GetDatabaseValuesAsync();
      if (databaseEntry == null) ModelState.AddModelError("", "Yozuv allaqachon o'chirilgan");
      else ModelState.AddModelError("", "Yozuv kimdir tomonidan o'zgartirilgan");
    }
    return View(product);
  }

  public async Task<IActionResult> Details(int? id)
  {
    if (id == null) return NotFound();
    var product = await _context.Products.FindAsync(id);
    if (product == null) return NotFound();
    return View(product);
  }

  public async Task<IActionResult> Delete(int? id)
  {
    if (id == null) return NotFound();
    var product = await _context.Products.FindAsync(id);
    if (product == null) return NotFound();
    return View(product);
  }

  [HttpPost, ActionName("Delete")]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
    var product = await _context.Products.FindAsync(id);
    if (product != null)
    {
      _context.Products.Remove(product);
      _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(Index));
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Create(Product product)
  {
    if (ModelState.IsValid)
    {
      _context.Products.Add(product);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
    return View(product);
  }

}

