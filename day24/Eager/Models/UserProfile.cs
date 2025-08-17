namespace Eager.Models;

public class UserProfile
{
  public int Id { get; set; }
  public string Fullname { get; set; } = string.Empty;
  public string Address { get; set; } = string.Empty;

  public int UserId { get; set; }
  public User User { get; set; } = null!;
}
