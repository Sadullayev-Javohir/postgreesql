using Microsoft.EntityFrameworkCore;
using Crud1.Models;
using Crud1.Data;

bool RunApp = true;

while (RunApp)
{
  Console.WriteLine("=====CRUD TERMINAL=====");
  Console.WriteLine("\n1.Create");
  Console.WriteLine("2.Read");
  Console.WriteLine("3.Update");
  Console.WriteLine("4.Delete");
  Console.WriteLine("5.Exit");

  Console.WriteLine("Choose: ");
  var choice = Console.ReadLine();
  using var context = new AppDbContext();
  switch (choice)
  {
    case "1":
      {
        Console.WriteLine("Product name: ");
        var productName = Console.ReadLine();

        Console.WriteLine("Product price: ");
        var productPrice = decimal.Parse(Console.ReadLine());

        var product = new Product { Name = productName, Price = productPrice };

        context.Products.Add(product);
        context.SaveChanges();
        Console.WriteLine("✅ Product added");
        break;
      }

    case "2":
      {
        Console.WriteLine("All Product Lists: \n");

        var products = context.Products.ToList();

        foreach (var p in products)
        {
          Console.WriteLine($"Id: {p.Id} : Product: {p.Name} : Price: {p.Price}");
        }
      }
      break;
    case "3":
      {
        Console.WriteLine("You will change product id: ");
        var updateProduct = context.Products.Find(int.Parse(Console.ReadLine()));

        if (updateProduct != null)
        {
          Console.WriteLine("Update Product Name: ");
          updateProduct.Name = Console.ReadLine();

          Console.WriteLine("Update Product Price: ");
          updateProduct.Price = decimal.Parse(Console.ReadLine());
          Console.WriteLine("✅ Updated product");
          context.SaveChanges();
        }
        else
        {
          Console.WriteLine("Product id not found");
        }
        break;
      }
    case "4":
      {
        Console.WriteLine("You will remove id");
        var product = context.Products.Find(int.Parse(Console.ReadLine()));
        if (product != null)
        {
          context.Products.Remove(product);
          Console.WriteLine("Removed");
          context.SaveChanges();
        }
        else
        {
          Console.WriteLine("Not found");
        }
        break;
      }
    case "5":
      RunApp = false;
      break;

    default:
      Console.WriteLine("Enter Other choice");
      break;
  }
}
