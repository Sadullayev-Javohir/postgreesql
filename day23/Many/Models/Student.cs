namespace Many.Models;

public class Student
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;

  public ICollection<StudentCourse> StudentCourses = new List<StudentCourse>();
}
