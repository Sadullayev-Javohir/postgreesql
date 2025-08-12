using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Commerce.Data;
using Commerce.Models;

var config = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json")
  .Build();

var options = new DbContextOptionsBuilder<AppDbContext>()
  .UseNpgsql(config.GetConnectionString("DefaultConnection"))
  .Options;

using var context = new AppDbContext(options);

var category = new Category { Name = "Electronics" };
var product = new Product { Name = "Laptop", Price = 1560, Category = category };

context.Categories.Add(category);
context.Products.Add(product);
context.SaveChanges();

Console.WriteLine("Ma'lumotlar qo'shildi");
