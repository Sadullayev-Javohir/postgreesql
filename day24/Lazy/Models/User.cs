using System.Collections.Generic;

namespace Lazy.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; }

    // ⚠️ Lazy loading ishlashi uchun virtual
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
  }
}
