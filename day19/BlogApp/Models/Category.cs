using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models;

public class Category
{
  [Key]
  public int Id { get; set; }

  [Required, MaxLength(100)]
  public string Name { get; set; } = string.Empty;

  public ICollection<Post> Posts { get; set; } = new List<Post>();
}
