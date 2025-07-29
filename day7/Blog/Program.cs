using Blog.Data;
using Blog.Models;

class Program
{
  static void Main()
  {
    using (var context = new BlogContext())
    {
      var tech = new Category { Name = "Texnologiya" };
      context.Categories.Add(tech);
      context.SaveChanges();
      var post = new Post
      {
        Title = "EF Core Code First haqida",
        Content = "Bu maqolada EF Core Code First haqida o'rganamiz.",
        PublishedDate = DateTime.UtcNow,
        CategoryId = tech.Id
      };
      context.Posts.Add(post);
      context.SaveChanges();

      Console.WriteLine("Ma'lumotlar saqlandi.");
    }
  }
}
