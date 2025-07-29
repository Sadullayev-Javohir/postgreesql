using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
  public class Post
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }
    
    [Required]
    public string Author { get; set; } = "Admin";

    [Required]
    public string Content { get; set; }

    public DateTime PublishedDate { get; set; } = DateTime.UtcNow;

    // Foreign Key
    public int CategoryId { get; set; }

    // Navigation
    public Category Category { get; set; }
    public List<Comment> Comments { get; set; }
  }
}
