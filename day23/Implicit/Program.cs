using Microsoft.EntityFrameworkCore;
using Implicit.Models;
using Implicit.Data;

using var db = new AppDbContext();

// var student1 = new Student { Name = "Javohir" };
// var student2 = new Student { Name = "Yusuf" };

// var course1 = new Course { Title = "Ingliz tili" };
// var course2 = new Course { Title = "Matematika" };

// student1.Courses.Add(course1);
// student1.Courses.Add(course2);

// student2.Courses.Add(course2);

// db.Students.AddRange(student1, student2);
// db.SaveChanges();
// Console.WriteLine("Saqlandi");

var students = db.Students
  .Include(s => s.Courses)
  .ToList();

foreach (var s in students)
{
  Console.WriteLine("Name: " + s.Name);

  foreach (var c in s.Courses)
  {
    Console.WriteLine("  -  Course: " + c.Title);
  }
}

