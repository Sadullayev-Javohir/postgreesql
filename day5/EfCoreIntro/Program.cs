public class Blog
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Url { get; set; }
}

class Program
{
  static void Main()
  {
    using (var context = new AppDbContext())
    {
      var blog = new Blog() { Name = "The latest blog", Url = "https://example.com" };
      context.Blogs.Add(blog);
      context.SaveChanges();

      foreach (var b in context.Blogs)
      {
        Console.WriteLine($"Id: {b.Id}, Name: {b.Name}, Url: {b.Url}");
      }
    }
  }
}
