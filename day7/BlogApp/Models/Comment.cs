using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
  public class Comment
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string AuthorName { get; set; }

    [Required]
    public string Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int PostId { get; set; }

    public Post Post { get; set; }
  }
}
