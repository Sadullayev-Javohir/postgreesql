using Microsoft.EntityFrameworkCore;
using App3.Data;
using App3.Models;

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
    EnrollmentDate = DateTime.Now
  };

  var sc2 = new StudentCourse
  {
    Student = student1,
    Course = course2,
    EnrollmentDate = DateTime.Now
  };

  var sc3 = new StudentCourse
  {
    Student = student2,
    Course = course1,
    EnrollmentDate = DateTime.Now
  };

  context.StudentCourses.AddRange(sc1, sc2, sc3);
  context.SaveChanges();

  Console.WriteLine("Ma'lumotlar qo'shildi");
}

var students = context.Students
  .Include(s => s.StudentCourses)
  .ThenInclude(sc => sc.Course)
  .ToList();

foreach (var s in students)
{
  Console.WriteLine($"Talaba: {s.Name}");

  foreach (var sc in s.StudentCourses)
  {
    Console.WriteLine($" - Kurs: {sc.Course.Title} (Ro'yxatdan o'tgan sana: {sc.EnrollmentDate})");
  }
}


