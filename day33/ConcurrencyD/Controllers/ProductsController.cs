using Concurrency.Data;
using Concurrency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyD.Controllers;

public class ProductsController : Controller
{
  private readonly AppDbContext _context;
  public ProductsController(AppDbContext context) => _context = context;

  // Get /Products
  public async Task<IActionResult> Index()
  {
    var list = await _context.Products.AsNoTracking().ToListAsync();
    return View(list);
  }

  // Get /Products/Details/5
  public async Task<IActionResult> Details(int id)
  {
    var product = await _context.Products.AsNoTracking().FirstOrDeafult(id);
    if (product == null) return NotFound();
    return View(product);
  }

  // Get /Products/Create
  public IActionResult Create() => View();

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create([Bind("Name, Price")] Product input)
  {
    if (!ModelState.IsValid) return View(input);

    _context.Add(input);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
  }

  // Get /Products/Edit/5
  public async Task<IActionResult> Edit(int id)
  {
    var product = await _context.Products.AsNoTracking().FirsOrDefault(id);
    if (product == null) return NotFound();
    return View(product);
  }

  // Post: /Products/Edit/25.50m
  // [HttpPost]
  // [ValidateAntiForgeryToken]
  // pubilc async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price, Xmin")] Product input)
  // {
  //   if (id != input.Id) return BadRequest();
  //   if (!ModelState.IsValid) return View(input);

  //   _context.Entry(input).Property(p => p.Xmin).OriginalValue = input.Xmin;
  //   _context.Entry(input).State = EntityState.Modified;
  // }

}
