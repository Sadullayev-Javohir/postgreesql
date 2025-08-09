using Microsoft.EntityFrameworkCore;
using Explicit.Data;
using Explicit.Models;

using var context = new AppDbContext();

if (!context.Students.Any())
{
  var student1 = new Student { Name = "Ali" };
  var student2 = new Student { Name = "Vali" };

  var course1 = new Course { Title = "Matematika" };
  var course2 = new Course { Title = "Fizika" };

  var sc1 = new StudentCourse
  {
    Student = student1,
    Course = course1,
    EnrollmentDate = DateTime.UtcNow
  };

  var sc2 = new StudentCourse
  {
    Student = student1,
    Course = course2,
    EnrollmentDate = DateTime.UtcNow
  };

  var sc3 = new StudentCourse
  {
    Student = student2,
    Course = course1,
    EnrollmentDate = DateTime.UtcNow
  };

  context.StudentCourses.AddRange(sc1, sc2, sc3);
  context.SaveChanges();

  Console.WriteLine("Qoshildi");
}
