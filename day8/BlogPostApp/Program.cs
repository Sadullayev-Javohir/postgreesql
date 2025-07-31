using System;
using BlogPostApp.Data;
using BlogPostApp.Models;

class Program
{
  static void Main()
  {
    using var db = new AppDbContext();

    var post = new Post
    {
      Title = "EF Core Code First",
      Content = "Bu maqola EF Core Code First haqida."
    };

    db.Postss.Add(post);
    db.SaveChanges();

    Console.WriteLine("Post muvaffaqiyatli qo'shildi");
  }
}
