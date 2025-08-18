using LinqToEntity.Data;
using Microsoft.EntityFrameworkCore;

namespace LinqToEntity.Services;

public class ProductService
{
  private readonly AppDbContext _db;

  public ProductService(AppDbContext db)
  {
    _db = db;
  }

  public void RunQueries()
  {
    // var cheaper = _db.Products
    //   .Where(p => p.Price < 100)
    //   .Include(p => p.Category)
    //   .ToList();
    // Console.WriteLine("Cheaper Products (< 100): ");
    // cheaper.ForEach(p => Console.WriteLine($"Category: {p.Category!.Name} - {p.Name} : {p.Price}"));

    // var ordered = _db.Products
    //   .OrderBy(p => p.Price)
    //   .Include(p => p.Category)
    //   .ToList();

    // Console.WriteLine($"Increase: ");
    // ordered.ForEach(p => Console.WriteLine($"Id: {p.Id} ==  Category: {p.Category!.Name} == {p.Name} -- ${p.Price}"));

    // var orderedDescending = _db.Products
    //   .OrderByDescending(p => p.Price)
    //   .Include(p => p.Category)
    //   .ToList();

    // Console.WriteLine("Descending: ");
    // orderedDescending.ForEach(p => Console.WriteLine($"Id: {p.Id} ==  Category: {p.Category!.Name} == {p.Name} -- ${p.Price}"));

    // var names = _db.Products
    //   .Select(p => p.Name)
    //   .ToList();

    // Console.WriteLine("Product Names: ");
    // names.ForEach(Console.WriteLine);

    // var names = _db.Products
    //   .Select(p => new {p.Name, p.Price})
    //   .ToList();

    // Console.WriteLine("Product Info (Name: Price): ");
    // names.ForEach(p => Console.WriteLine($" - {p.Name} : ${p.Price}"));

    // var joined = _db.Products
    //   .Include(p => p.Category)
    //   .Select(p => new { p.Name, p.Price, Category = p.Category!.Name })
    //   .ToList();

    // Console.WriteLine("Products with Category: ");
    // joined.ForEach(p => Console.WriteLine($" - {p.Name} : {p.Category}"));

    // var grouped = _db.Products
    //   .GroupBy(p => p.CategoryId)
    //   .Select(g => new { CategoryId = g.Key, Count = g.Count() })
    //   .ToList();

    // Console.WriteLine("Products Grouped by CategoryId: ");
    // grouped.ForEach(g => Console.WriteLine($" - Category {g.CategoryId} : {g.Count} products"));

    // var firstProduct = _db.Products.FirstOrDefault();
    // Console.WriteLine($" First Product: {firstProduct?.Name}");

    // var cheap = _db.Products.Any(p => p.Price < 50);
    // Console.WriteLine($" First Product: {cheap}");

    var count = _db.Products.Count();
    Console.WriteLine($"\nTotal Products: {count}");
  }

}

