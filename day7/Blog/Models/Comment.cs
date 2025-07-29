using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
  public class Comment
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string? AuthorName { get; set; }

    [Required]
    public string? Content { get; set; }

    public DateTime CreateAt { get; set; }

    public int PostId { get; set; }

    public Post Post { get; set;}

  }
}
