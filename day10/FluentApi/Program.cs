using FluentApi.Data;
using FluentApi.Models;


using var context = new AppDbContext();

context.Database.EnsureCreated();

context.Students.Add(new Student
{
  FullName = "Ali Valiyev",
  Email = "email@.gmail.com",
  BirthDate = new DateTime(2000, 5, 1)
});

context.SaveChanges();

Console.WriteLine("Saqlandi");
