using System.ComponentModel.DataAnnotations;

namespace ConcurrencyExe.Models;

public class Product
{
  public int Id { get; set; }
  [Required]
  public string Name { get; set; }
  public decimal Price { get; set; }

  [Timestamp]
  public uint xmin { get; set; }
}
