using Microsoft.EntityFrameworkCore;
using Blog3.Models;
using Blog3.Data;

using var db = new AppDbContext();

var blog = new BlogPost
{
  Title = "Ef Core One-to-Many",
  Content = "Bu misolda blogpost va comment ko'rsatiladi",
  Comments = new List<Comment>
  {
    new Comment {Text = "Birinchi comment"},
    new Comment {Text = "Ikkinchi comment"}
  }
};

db.BlogPosts.Add(blog);

db.SaveChanges();

var posts = db.BlogPosts.Include(p => p.Comments);

foreach (var p in posts)
{
  Console.WriteLine($"Post: {p.Title}");
  Console.WriteLine($"Content: {p.Content}");
  Console.WriteLine("Comments:");

  foreach (var c in p.Comments)
  {
    Console.WriteLine($" - {c.Text}");
  }
  Console.WriteLine(new string('-', 30));
}
