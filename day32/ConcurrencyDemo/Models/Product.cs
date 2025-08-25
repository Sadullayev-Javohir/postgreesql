
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcurrencyDemo.Models
{
  public class Product
  {
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Name { get; set; } = default!;

    [Range(0, 999999)]
    [Column(TypeName = "numeric(18,2)")]
    public decimal Price { get; set; }

    // PostgreSQL system column (concurrency token)
    // EF bu qiymatni o‘zi boshqaradi; biz formda hidden field sifatida yuboramiz.
    [ScaffoldColumn(false)]
    public uint Xmin { get; set; }
  }
}
