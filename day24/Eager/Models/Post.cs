namespace Eager.Models;

public class Post
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;

  public int UserId { get; set; }
  public User User { get; set; } = null!;
}
