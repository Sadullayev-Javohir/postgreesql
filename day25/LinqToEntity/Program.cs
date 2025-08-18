using LinqToEntity.Models;
using LinqToEntity.Data;
using Microsoft.EntityFrameworkCore;
using LinqToEntity.Services;


using var db = new AppDbContext();

var service = new ProductService(db);
service.RunQueries();


if (!db.Categories.Any())
{
  // Kategoriyalarni yaratish
  var cat1 = new Category { Name = "Electronics" };
  var cat2 = new Category { Name = "Books" };
  var cat3 = new Category { Name = "Clothing" };
  var cat4 = new Category { Name = "Sports" };
  var cat5 = new Category { Name = "Home & Garden" };
  var cat6 = new Category { Name = "Toys & Games" };
  var cat7 = new Category { Name = "Beauty & Health" };

  db.Categories.AddRange(cat1, cat2, cat3, cat4, cat5, cat6, cat7);

  // Mahsulotlarni qo'shish
  db.Products.AddRange(
      // Electronics
      new Product { Name = "Laptop", Price = 1200, Category = cat1 },
      new Product { Name = "Phone", Price = 800, Category = cat1 },
      new Product { Name = "Tablet", Price = 500, Category = cat1 },
      new Product { Name = "Smart TV", Price = 1500, Category = cat1 },
      new Product { Name = "Headphones", Price = 150, Category = cat1 },
      new Product { Name = "Camera", Price = 700, Category = cat1 },

      // Books
      new Product { Name = "C# Programming", Price = 50, Category = cat2 },
      new Product { Name = "SQL Guide", Price = 40, Category = cat2 },
      new Product { Name = "Python Basics", Price = 45, Category = cat2 },
      new Product { Name = "Web Development", Price = 60, Category = cat2 },
      new Product { Name = "Data Science", Price = 55, Category = cat2 },

      // Clothing
      new Product { Name = "T-shirt", Price = 25, Category = cat3 },
      new Product { Name = "Jeans", Price = 60, Category = cat3 },
      new Product { Name = "Jacket", Price = 120, Category = cat3 },
      new Product { Name = "Dress", Price = 80, Category = cat3 },
      new Product { Name = "Shoes", Price = 95, Category = cat3 },

      // Sports
      new Product { Name = "Football", Price = 30, Category = cat4 },
      new Product { Name = "Basketball", Price = 35, Category = cat4 },
      new Product { Name = "Running Shoes", Price = 110, Category = cat4 },
      new Product { Name = "Gym Equipment", Price = 350, Category = cat4 },

      // Home & Garden
      new Product { Name = "Sofa", Price = 600, Category = cat5 },
      new Product { Name = "Dining Table", Price = 450, Category = cat5 },
      new Product { Name = "Bed", Price = 800, Category = cat5 },
      new Product { Name = "Plants", Price = 25, Category = cat5 },
      new Product { Name = "Kitchenware Set", Price = 200, Category = cat5 },

      // Toys & Games
      new Product { Name = "Board Game", Price = 40, Category = cat6 },
      new Product { Name = "Puzzle", Price = 20, Category = cat6 },
      new Product { Name = "Action Figure", Price = 15, Category = cat6 },
      new Product { Name = "Video Game", Price = 60, Category = cat6 },

      // Beauty & Health
      new Product { Name = "Shampoo", Price = 15, Category = cat7 },
      new Product { Name = "Perfume", Price = 85, Category = cat7 },
      new Product { Name = "Facial Cream", Price = 35, Category = cat7 },
      new Product { Name = "Vitamins", Price = 30, Category = cat7 }
  );
}

db.SaveChanges();
Console.WriteLine("Ma'lumotlar muvaffaqiyatli qo'shildi!");
