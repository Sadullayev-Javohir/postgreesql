using CRUD.Data;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

bool runApp = true;

while (runApp)
{
  Console.WriteLine("\n=== PRODUCT CRUD MENU ===");
  Console.WriteLine("1. Add Product");
  Console.WriteLine("2. View All Products");
  Console.WriteLine("3. Update Product");
  Console.WriteLine("4. Delete Product");
  Console.WriteLine("5. Exit");
  Console.Write("Tanlang: ");
  var choice = Console.ReadLine();

  using var context = new AppDbContext();

  switch (choice)
  {
    case "1":
      Console.WriteLine("Mahsulot nomi: ");
      var name = Console.ReadLine();

      Console.WriteLine("Narxi: ");
      var price = decimal.Parse(Console.ReadLine());

      var product = new Product { Name = name, Price = price };
      context.Products.Add(product);
      context.SaveChanges();
      Console.WriteLine("✅ Mahsulot qo'shildi");
      break;
    case "2":
      var products = context.Products.ToList();
      Console.WriteLine("\n--- Mahsulotlar ---");
      foreach (var p in products)
      {
        Console.WriteLine($"{p.Id} : {p.Name} - ${p.Price}");
      }
      break;
    case "3":
      Console.WriteLine("Yangilash uchun mahsulot Id: ");
      int updateId = int.Parse(Console.ReadLine());

      var updateProduct = context.Products.Find(updateId);

      if (updateProduct != null)
      {
        Console.WriteLine("Yangi nom: ");
        var newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
          updateProduct.Name = newName;

        Console.WriteLine("Yangi narx: ");
        var newPrice = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newPrice))
          updateProduct.Price = decimal.Parse(newPrice);

        context.SaveChanges();
        Console.WriteLine("✅ Mahsulot yangilandi");
      }
      else
      {
        Console.WriteLine("❌ Mahsulotlar topilmadi");
      }
      break;

    case "4":
      Console.WriteLine("O'chirish uchun mahsulot Id: ");
      int deleteId = int.Parse(Console.ReadLine());

      var productDelete = context.Products.Find(deleteId);
      if (productDelete != null)
      {
        context.Products.Remove(productDelete);
        context.SaveChanges();
        Console.WriteLine("✅ Mahsulot qo'shildi");
      }
      else
      {
        Console.WriteLine("Mahsulot topilmadi");
      }
      break;

    case "5":
      runApp = false;
      Console.WriteLine("Dastur tugadi");
      break;

    default:
      Console.WriteLine("❌ Noto‘g‘ri tanlov, qaytadan urinib ko‘ring.");
      break;
  }
}
