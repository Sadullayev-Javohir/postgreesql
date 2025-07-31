using System;

using BlogSystem.Data;
using BlogSystem.Models;

class Program
{
  static void Main()
  {
    using (var db = new AppDbContext())
    {
      var post = new Post
      {
        Title = "Ef Core Code First",
        Content = "Bu maqola Ef Core Code First haqida.",
      };

      db.Posts.Add(post);
      db.SaveChanges();

      Console.WriteLine("Post muvaffaqiyatli qo'shildi");
    }
  }
}
