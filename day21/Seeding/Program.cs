using Microsoft.EntityFrameworkCore;
using Seeding.Data;
using Seeding.Models;

using var context = new ApplicationDbContext();

var products = context.Products.ToList();

foreach (var p in products)
{
  Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}");
}
