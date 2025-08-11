namespace ECommerceApp.Models
{
  public class Order
  {
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
  }
}
