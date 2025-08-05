using var context = new AppDbContext();

var products = context.Products.ToList();

foreach (var product in products)
{
  Console.WriteLine($"{product.Id} : {product.Name}, {product.Price}");
}
