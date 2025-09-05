using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ConcurrencyDemo.Models;
using ConcurrencyDemo.Data;

namespace ConcurrencyDemo.Controllers;

public class ProductsController : Controller
{
  private readonly ApplicationDbContext _context;
  public ProductsController(ApplicationDbContext context) => _context = context;

  public async Task<IActionResult> Index()
  {
    var products = await _context.Products.ToListAsync();
    return View(products);
  }

  public async Task<IActionResult> Details(int? id)
  {
    if (id == null) return NotFound();
    var product = await _context.Products.FindAsync(id);
    if (product == null) return NotFound();
    return View(product);
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(Product product)
  {
    if (!ModelState.IsValid) return View(product);

    _context.Add(product);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
  }

  public async Task<IActionResult> Edit(int? id)
  {
    if (id == null) return NotFound();
    var product = await _context.Products.FindAsync(id);
    if (product == null) return NotFound();
    return View(product);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(int id, Product product)
  {
    if (id != product.Id) return NotFound();

    try
    {
      _context.Update(product);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
    catch (DbUpdateConcurrencyException ex)
    {
      var dbValues = await ex.Entries.Single().GetDatabaseValuesAsync();

      if (dbValues == null) ModelState.AddModelError("", "Bu mahsulot allaqachon o'chirilgan");
      else ModelState.AddModelError("", "Bu mahsulot kimdir tomonidan o'zgartirilgan");
    }
    return View(product);
  }

  public async Task<IActionResult> Delete(int? id)
  {
    if (id == null) return NotFound();
    var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

    if (product == null) return NotFound();
    return View(product);
  }

  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
    var product = await _context.Products.FindAsync(id);
    if (product != null)
    {
      _context.Products.Remove(product);
      await _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(Index));
  }
}
