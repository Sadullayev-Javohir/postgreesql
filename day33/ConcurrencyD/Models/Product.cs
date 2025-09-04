using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcurrencyD.Models
{
  public class Product
  {
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Name { get; set; }

    [Range(0, 999999)]
    [Column(TypeName = "numeric(18,2)")]
    public decimal Price { get; set; }

    [ScaffoldColumn(false)]
    public uint Xmin { get; set; }
  }
}
