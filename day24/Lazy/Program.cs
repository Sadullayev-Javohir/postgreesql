using Lazy.Data;
using Lazy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

// DbContext sozlash (OnConfiguring emas!)
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseNpgsql("Host=localhost;Port=5432;Database=localdb;Username=javohir;Password=1234")
    .UseLazyLoadingProxies() // 👈 muhim
    .Options;

using var db = new AppDbContext(options);

// Seed: agar bo'sh bo'lsa bitta user va 2 post qo'shamiz
if (!db.Users.Any())
{
  var u = new User { Name = "Ali" };
  u.Posts.Add(new Post { Title = "Birinchi post", Content = "Salom!" });
  u.Posts.Add(new Post { Title = "Ikkinchi post", Content = "Yana salom!" });

  db.Users.Add(u);
  db.SaveChanges();
  Console.WriteLine("🌱 Seed qilindi.");
}

var user = db.Users.First();

Console.WriteLine($"Foydalanuvchi: {user.Name}");

Console.WriteLine("Postlar soni : " + user.Posts.Count);

foreach (var p in user.Posts)
{
  Console.WriteLine($"  - {p.Title} : {p.Content}");
}
