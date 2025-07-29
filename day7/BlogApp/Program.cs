using BlogApp.Data;
using BlogApp.Models;

  var context = new BlogContext();
  context.Database.EnsureCreated(); // Dastlab bazani yaratish

// Kategoriya yaratish
var category = new Category { Name = "Texnologiya" };
context.Categories.Add(category);
context.SaveChanges();

// Post yaratish
var post = new Post
{
  Title = "EF Core Code First",
  Content = "Bugun EF Core migratsiyasini o‘rganamiz.",
  CategoryId = category.Id
};
context.Posts.Add(post);
context.SaveChanges();

Console.WriteLine("Ma'lumotlar saqlandi.");
