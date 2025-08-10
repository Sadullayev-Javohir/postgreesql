using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Data;

var connectionString = "Host=localhost;Port=5432;Password=1234;Username=javohir;Database=loading";

var options = new DbContextOptionsBuilder<
ApplicationDbContext>()
  .UseNpgsql(connectionString)
  .Options;

using var context = new ApplicationDbContext(options);

var category1 = new Category { Name = "Electronics" };
var category2 = new Category { Name = "Books" };

var product1 = new Product { Name = "Smartphone", Category = category1 };
var product2 = new Product { Name = "Laptop", Category = category1 };
var product3 = new Product { Name = "Novel", Category = category2 };

context.Categories.AddRange(category1, category2);
context.Products.AddRange(product1, product2, product3);
context.SaveChanges();


var productsWithCategory = context.Products
  .Include(p => p.Category)
  .ToList();

foreach (var product in productsWithCategory)
{
  Console.WriteLine($"Product: {product.Name}, Category: {product.Category.Name}");
}
