using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BlogApp.Models;
using BlogApp.Data;

var config = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json")
  .Build();

var options = new DbContextOptionsBuilder<AppDbContext>()
.UseNpgsql(config.GetConnectionString("DefaultConnection"))
.Options;

using var context = new AppDbContext(options);

var category = new Category { Name = "Programming" };
context.Categories.Add(category);
context.SaveChanges();

Console.WriteLine("Category qo'shildi");
