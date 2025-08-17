using Microsoft.EntityFrameworkCore;
using Eager.Models;
using Eager.Data;

using var db = new AppDbContext();

if (!db.Users.Any())
{
  var user = new User
  {
    Username = "coder",
    UserProfile = new UserProfile { Fullname = "Ali Valiyev", Address = "Tashkent" },
    Posts = new List<Post>
    {
      new Post {Title = "Birinchi post"},
      new Post {Title = "Ikkinchi post"}
    }
  };

  db.Users.Add(user);
  db.SaveChanges();
}

var eagerUser = db.Users
  .Include(u => u.UserProfile)
  .Include(u => u.Posts)
  .FirstOrDefault();

Console.WriteLine($"[Eager] Users: {eagerUser.Username}, Profile: {eagerUser.UserProfile.Fullname}");
foreach (var post in eagerUser.Posts)
{
  Console.WriteLine($"   Post: {post.Title}");
}
