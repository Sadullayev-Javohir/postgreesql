namespace Eager.Models;

public class User
{
  public int Id { get; set; }
  public string Username { get; set; } = string.Empty;

  public UserProfile UserProfile { get; set; } = null!;
  public List<Post> Posts { get; set; } = new();
}
