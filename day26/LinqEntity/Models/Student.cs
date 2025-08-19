using System.Collections.Generic;

namespace LinqEntity.Models;

public class Student
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string GroupName { get; set; } = "";

  public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
