using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models;

public class Post
{
  [Key]
  public int Id { get; set; }

  [Required, MaxLength(200)]
  public string Title { get; set; } = string.Empty;

  [Required]
  public string Content { get; set; } = string.Empty;

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public int CategoryId { get; set; }
  public Category Category { get; set; }

  public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
