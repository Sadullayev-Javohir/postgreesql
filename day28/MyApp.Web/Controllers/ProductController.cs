using Microsoft.AspNetCore.Mvc;
using MyApp.Web.Models;
using MyApp.Web.Repositories;

namespace MyApp.Web.Controllers;

public class ProductController : Controller
{
  private readonly ProductRepository _repository;

  public ProductController(ProductRepository repository)
  {
    _repository = repository;
  }

  public async Task<IActionResult> Index()
  {
    var products = await _repository.GetAllAsync();
    return View(products);
  }

  [HttpPost]
  public async Task<IActionResult> Create(Product product)
  {
    if (ModelState.IsValid)
    {
      await _repository.AddAsync(product);
      return RedirectToAction("Index");
    }
    return View(product);
  }
}
