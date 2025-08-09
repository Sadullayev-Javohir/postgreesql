using Microsoft.EntityFrameworkCore;
using Many.Models;
using Many.Data;

using var context = new AppDbContext();

if (!context.Students.Any())
{
  var course1 = new Course { Title = "Matematika" };
  var course2 = new Course { Title = "Fizika" };

  var student1 = new Student { Name = "Ali" };
  var student2 = new Student { Name = "Vali" };

  student1.Courses.Add(course1);
  student1.Courses.Add(course2);
  student2.Courses.Add(course1);

  context.Students.AddRange(student1, student2);
  context.SaveChanges();

  Console.WriteLine("Qo'shildi");
}

var students = context.Students
  .Include(s => s.Courses)
  .ToList();

foreach (var s in students)
{
  Console.WriteLine($"Talaba: {s.Name}");

  foreach (var c in s.Courses)
  {
    Console.WriteLine($" - Kurs: {c.Title}");
  }
}
