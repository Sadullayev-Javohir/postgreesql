using Microsoft.EntityFrameworkCore;
using One.Models;
using One.Data;


using var db = new AppDbContext();

// var user = new User
// {
//   UserName = "coder_uz",
//   UserProfile = new UserProfile
//   {
//     FullName = "Javohir Sadullayev",
//     Address = "Tashkent"
//   }
// };

// db.Users.Add(user);
// db.SaveChanges();

// Console.WriteLine("Saqlandi");

var user = db.Users
  .Include(u => u.UserProfile)
  .ToList();

foreach (var u in user)
{
  Console.WriteLine("User: " + u.UserName);
  Console.WriteLine("   -FullName: " + u.UserProfile.FullName);
  Console.WriteLine("   -Address: " + u.UserProfile.Address);
}
