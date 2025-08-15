using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;

using var db = new AppDbContext();

var post = new BlogPost
{
  Title = "Ef Core One-to-Many Misol",
  Content = "Bu misolda blog post va commentlar ko'rsatiladi",
  Comments = new List<Comment>
  {
    new Comment {Text = "Birinchi commment"},
    new Comment {Text = "Ikkinchi comment"}
  }
};

db.BlogPosts.Add(post);
db.SaveChanges();

var posts = db.BlogPosts.Include(p => p.Comments);

foreach (var p in posts)
{
  Console.WriteLine($"Post: {p.Title}");
  Console.WriteLine($"Content: {p.Content}");
  Console.WriteLine($"Comments: ");
  foreach (var c in p.Comments)
  {
    Console.WriteLine($" - {c.Text}");
  }
  Console.WriteLine(new string('-', 30));
}
