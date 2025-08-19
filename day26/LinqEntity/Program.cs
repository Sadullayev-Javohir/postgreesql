using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LinqEntity.Data;
using LinqEntity.Models;
using LinqEntity.Reports;

var config = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json")
.Build();

var options = new DbContextOptionsBuilder<AppDbContext>()
  .UseNpgsql(config.GetConnectionString("DefaultConnection"))
  .Options;

using var context = new AppDbContext(options);

if (!context.Students.Any())
{
  var students = new[]
  {
        new Student { Name = "Ali", GroupName = "A1" },
        new Student { Name = "Vali", GroupName = "A1" },
        new Student { Name = "Gul", GroupName = "B1" },
    };

  var courses = new[]
  {
        new Course { Title = "Matematika" },
        new Course { Title = "Fizika" },
        new Course { Title = "Ingliz tili" }
    };

  context.Students.AddRange(students);
  context.Courses.AddRange(courses);
  context.SaveChanges();

  var enrollments = new[]
  {
        new Enrollment { StudentId = students[0].Id, CourseId = courses[0].Id, Grade = 90 },
        new Enrollment { StudentId = students[0].Id, CourseId = courses[1].Id, Grade = 80 },
        new Enrollment { StudentId = students[1].Id, CourseId = courses[0].Id, Grade = 70 },
        new Enrollment { StudentId = students[2].Id, CourseId = courses[2].Id, Grade = 95 }
    };

  context.Enrollments.AddRange(enrollments);
  context.SaveChanges();
}

var queries = new LinqQueries(context);

// Console.WriteLine("Kurs bo'yicha guruhlash");
// queries.GroupByCourses();

// Console.WriteLine("Kurs va Ismi");
// queries.JoinStudentsCourses();


// Console.WriteLine("Talaba va fanlari");
// queries.SelectManyExample();



// Console.WriteLine("Kurs va o'rtacha baho");
// queries.AverageGrade();



