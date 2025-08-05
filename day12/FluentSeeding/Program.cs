using FluentSeeding.Data;


using var context = new AppDbContext();

var products = context.Products.ToList();

foreach (var p in products)
{
  Console.WriteLine($"{p.Id}. {p.Title} - {p.Cost} so'm - {(p.InStock ? "Bor" : "Yo'q")}");
}
