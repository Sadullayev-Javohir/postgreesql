using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using Blog.Models;

public class Post
{
  [Key]
  public int Id { get; set; }

  [Required]
  [StringLength(200)]
  public string? Title { get; set; }

  [Required]
  public string? Content { get; set; }

  public DateTime PublishedDate { get; set; } = DateTime.UtcNow;

  public int CategoryId { get; set; }

  public Category Category { get; set; }

  public List<Comment> Comments { get; set; }
}
