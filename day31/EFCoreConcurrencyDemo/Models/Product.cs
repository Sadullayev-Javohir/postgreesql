using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreConcurrencyDemo.Models;

public class Product
{
  public int Id { get; set; }

  [Required]
  public string Name { get; set; } = "";

  [Column(TypeName = "decimal(18,2)")]
  public decimal Price { get; set; }

  [Timestamp]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public uint RowVersion { get; set; }
}
