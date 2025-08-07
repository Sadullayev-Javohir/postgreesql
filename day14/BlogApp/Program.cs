using BlogApp.Models;
using BlogApp.Data;
using Microsoft.EntityFrameworkCore;

using var db = new AppDbContext();

var post = new BlogPost { Title = "Hello Ef EntityFrameworkCore", Content = "This is an example" };

var comment1 = new Comment { Text = "Great post!", BlogPost = post };
var comment2 = new Comment { Text = "Thanks for sharing!", BlogPost = post };

db.BlogPosts.Add(post);
db.Comments.AddRange(comment1, comment2);
db.SaveChanges();

var posts = db.BlogPosts.Include(p => p.Comments).ToList();

foreach (var p in posts)
{
  Console.WriteLine($"Posts: {p.Title}");

  foreach (var c in p.Comments)
  {
    Console.WriteLine($" - {c.Text}");
  }
}
