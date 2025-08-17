namespace Explicit.Models
{
  public class Post
  {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    // Foreign key
    public int UserId { get; set; }
    public User User { get; set; } = null!;
  }
}
