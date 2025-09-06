using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
  private readonly ApplicationDbContext _context;

  public ProductController(ApplicationDbContext context)
  {
    _context = context;
  }

  public IActionResult Delete(int id)
  {
    var product = _context.Products.Find(id);
    if (product != null)
    {
      product.IsDeleted = true;
      _context.SaveChanges();
    }

    return RedirectToAction("Index");
  }

  public IActionResult Index()
  {
    var products = _context.Products.ToList();
    return View(products);
  }
}
