using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Many.Data;
using Many.Models;

using var db = new AppDbContext();

var math = new Course { Title = "Matematika" };
var physics = new Course { Title = "Fizika" };

var student1 = new Student
{
  Name = "Ali",
  Course = new List<Course> { math, physics }
};

var student2 = new Student
{
  Name = "Vali",
  Course = new List<Course> { physics }
};

db.Students.AddRange(student1, student2);
db.SaveChanges();

var students = db.Students.Include(s => s.Courses);

foreach (var s in students)
{
  Console.WriteLine($"Student: {s.Name}");
  Console.WriteLine("Courses:");
  foreach (var c in s.Courses)
  {
    Console.WriteLine($"- {c.Title}");
  }
  Console.WriteLine(new string('-', 30));
}
