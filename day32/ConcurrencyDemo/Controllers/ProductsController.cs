using ConcurrencyDemo.Data;
using ConcurrencyDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyDemo.Controllers
{
  public class ProductsController : Controller
  {
    private readonly AppDbContext _context;
    public ProductsController(AppDbContext context) => _context = context;

    // GET: /Products
    public async Task<IActionResult> Index()
    {
      var list = await _context.Products.AsNoTracking().ToListAsync();
      return View(list);
    }

    // GET: /Products/Details/5
    public async Task<IActionResult> Details(int id)
    {
      var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
      if (product == null) return NotFound();
      return View(product);
    }

    // GET: /Products/Create
    public IActionResult Create() => View();

    // POST: /Products/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Price")] Product input)
    {
      if (!ModelState.IsValid) return View(input);

      _context.Add(input);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    // GET: /Products/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
      if (product == null) return NotFound();
      return View(product);
    }

    // POST: /Products/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Xmin")] Product input)
    {
      if (id != input.Id) return BadRequest();
      if (!ModelState.IsValid) return View(input);

      // Concurrency: EF ga original Xmin (formdan kelgan) beramiz
      _context.Entry(input).Property(p => p.Xmin).OriginalValue = input.Xmin;
      _context.Entry(input).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
        TempData["Success"] = "Ma'lumot muvaffaqiyatli yangilandi.";
        return RedirectToAction(nameof(Index));
      }
      catch (DbUpdateConcurrencyException)
      {
        // Bazadagi joriy holatni olib, foydalanuvchiga xabar beramiz
        var dbEntity = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (dbEntity == null)
        {
          // Ma'lumot o'chirib yuborilgan bo'lishi mumkin
          ModelState.AddModelError(string.Empty, "Yozuv boshqa foydalanuvchi tomonidan o‘chirildi.");
          return View(input);
        }
        ModelState.Clear();
        ModelState.AddModelError(string.Empty,
            "Concurrency konflikti: Yozuv boshqa foydalanuvchi tomonidan o‘zgartirilgan. " +
            "Quyida bazadagi joriy qiymatlar ko‘rsatilgan. Iltimos, qayta saqlang.");

        // Foydalanuvchiga joriy bazadagi qiymatlarni ko‘rsatish uchun yangilaymiz
        // (istasa o‘zgartirib, yana Saqlash tugmasini bosadi)
        var merged = new Product
        {
          Id = dbEntity.Id,
          Name = dbEntity.Name,
          Price = dbEntity.Price,
          Xmin = dbEntity.Xmin // endi bazadagi yangi xmin
        };

        return View(merged);
      }
    }

    // GET: /Products/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
      if (product == null) return NotFound();
      return View(product);
    }

    // POST: /Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, uint xmin)
    {
      var stub = new Product { Id = id, Xmin = xmin };
      _context.Entry(stub).Property(p => p.Xmin).OriginalValue = xmin;
      _context.Entry(stub).State = EntityState.Deleted;

      try
      {
        await _context.SaveChangesAsync();
        TempData["Success"] = "Yozuv o‘chirildi.";
        return RedirectToAction(nameof(Index));
      }
      catch (DbUpdateConcurrencyException)
      {
        TempData["Error"] = "Concurrency konflikti: yozuv o‘zgartirilgan yoki allaqachon o‘chirilgan.";
        return RedirectToAction(nameof(Index));
      }
    }
  }
}
