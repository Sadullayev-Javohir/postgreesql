using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models;

public class Comment
{
  [Key]
  public int Id { get; set; }

  [Required, MaxLength(500)]
  public string Text { get; set; } = string.Empty;

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public int PostId { get; set; }
  public Post? Post { get; set; }
}

