namespace Fluent.Models;

public class Student
{
  public int Id { get; set; }
  public string FullName { get; set; } = null!;
  public int Age { get; set; }
  public string Email { get; set; } = null!;
}
