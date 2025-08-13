using FluentApi.Data;
using FluentApi.Models;

using var context = new AppDbContext();

var student = new Student
{
  Name = "Rustam",
  Age = 35,
  Email = "rustam@gmail.com",
};

context.Students.Add(student);

context.SaveChanges();
Console.WriteLine("Ma'lumotlar qo'shildi");

foreach (var s in context.Students)
{
  Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}, Email: {s.Email}");
}
