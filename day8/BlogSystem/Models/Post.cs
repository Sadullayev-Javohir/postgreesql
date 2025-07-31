using System;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Models;


public class Post
{
  public int Id { get; set; }

  [Required]
  [MaxLength(200)]
  public required string Title { get; set; }

  [Required]
  public required string Content { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
