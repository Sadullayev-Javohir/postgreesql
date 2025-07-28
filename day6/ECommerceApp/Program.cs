using ECommerceApp.Models;

class Program
{
  static void Main()
  {
    using (var db = new AppDbContext())
    {
      var productsToAdd = new List<Product>
      {
        new Product { Name = "Iphone", Price = 1200m },
        new Product { Name = "Samsung", Price = 999.99m },
        new Product { Name = "Xiaomi", Price = 599.99m }
      };

      foreach (var product in productsToAdd)
      {
        bool exists = db.Products.Any(p => p.Name == product.Name);

        if (!exists)
        {
          db.Products.Add(product);
        }
      }

      db.SaveChanges();
      Console.WriteLine("Yangi mahsulotlar qo'shildi (agar mavjud bo'lmasa).");

    }
  }
}
