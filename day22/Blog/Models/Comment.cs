namespace Blog.Models;

public class Comment
{
  public int Id { get; set; }
  public string Text { get; set; } = string.Empty;

  public int BlogPostId { get; set; }

  public BlogPost BlogPost { get; set; } = new BlogPost();
}
