namespace FluentSeeding.Models;

public class Product
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public decimal Cost { get; set; }
  public bool InStock { get; set; }
}


