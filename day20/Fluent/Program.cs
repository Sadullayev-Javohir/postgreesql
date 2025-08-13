using Fluent.Data;
using Fluent.Models;

using var context = new AppDbContext();

var student = new Student
{
  FullName = "Javohir Sadullayev",
  Age = 22,
  Email = "@gmail.com"
};

context.Students.Add(student);

context.SaveChanges();

Console.WriteLine("Ma'lumotlar saqlandi!");
