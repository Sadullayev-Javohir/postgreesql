using Microsoft.EntityFrameworkCore;
using Many.Models;
using Many.Data;

using var db = new AppDbContext();

// var student1 = new Student { Name = "Javohir" };
// var student2 = new Student { Name = "Hasan" };

// var course1 = new Course { Title = "Matematika" };
// var course2 = new Course { Title = "Fizika" };

// student1.StudentCourses.Add(new StudentCourse { Course = course1 });
// student1.StudentCourses.Add(new StudentCourse { Course = course2 });

// student2.StudentCourses.Add(new StudentCourse { Course = course2 });

// db.Students.AddRange(student1, student2);
// db.SaveChanges();
// Console.WriteLine("Saqlandi");

var students = db.Students
  .Include(c => c.StudentCourses)
  .ThenInclude(sc => sc.Course)
  .ToList();

foreach (var s in students)
{
  Console.WriteLine("Students: " + s.Name);

  foreach (var sc in s.StudentCourses)
  {
    Console.WriteLine("Courses: " + sc.Course.Title);
  }   
}
