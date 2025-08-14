using System.ComponentModel.DataAnnotations;

namespace Crud1.Models;

public class Product
{
  [Key]
  public int Id { get; set; }

  [Required]
  [MinLength(2)]
  public string Name { get; set; }

  [Required]
  public decimal Price { get; set; }
}
