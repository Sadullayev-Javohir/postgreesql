namespace BlogApp.Models;

public class Comment
{
  public int Id { get; set; }
  public string Text { get; set; } = null!;

  public int BlogPostId { get; set; }

  public BlogPost BlogPost { get; set; } = null!;
}
