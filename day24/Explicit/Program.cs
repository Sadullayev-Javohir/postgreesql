using Microsoft.EntityFrameworkCore;
using Explicit.Data;
using Explicit.Models;

using var context = new AppDbContext();

if (!context.Users.Any())
{
  var user = new User
  {
    Username = "coder",
    Posts = new List<Post>
        {
          new Post { Title = "Birinchi post" },
          new Post { Title = "Ikkinchi post" },
          new Post { Title = "Uchinchi post" }
        }
  };
  context.Users.Add(user);
  context.SaveChanges();
  Console.WriteLine("✅ Test ma’lumotlari qo‘shildi!\n");
}

var userOnly = context.Users.First();

context.Entry(userOnly).Collection(u => u.Posts).Load();

Console.WriteLine($"User: {userOnly.Username}");

foreach (var post in userOnly.Posts)
{
  Console.WriteLine($"  Post: {post.Title}");
}
