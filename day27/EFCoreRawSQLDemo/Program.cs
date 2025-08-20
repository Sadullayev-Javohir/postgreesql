using EfCoreRawSQLDemo;
using EfCoreRawSQLDemo.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
  static void Main(string[] args)
  {
    using var context = new AppDbContext();

    Console.WriteLine("Yangi talaba qo'shilmoqda");
    context.Database.ExecuteSqlRaw(
      "INSERT INTO \"Students\" (\"FullName\", \"Age\") VALUES ('Ali Valiyev', 22)"
    );

    Console.WriteLine("Barcha talabalar ro'yxati: ");
    var students = context.Students
      .FromSqlRaw("SELECT * FROM \"Students\"")
    .ToList();

    foreach (var s in students)
    {
      Console.WriteLine($"{s.Id} - {s.FullName} - {s.Age}");
    }

    Console.WriteLine("20 yoshdan katta talabalar: ");
    int minAge = 20;
    var olderStudents = context.Students.FromSqlInterpolated($"SELECT * FROM \"Students\" WHERE \"Age\" >= {minAge}")
    .ToList();

    foreach (var s in olderStudents)
    {
      Console.WriteLine($"{s.FullName} ({s.Age})");
    }

    var studentsRaw = context.Students
      .FromSqlRaw("SELECT * FROM \"Students\"")
    .ToList();


    Console.WriteLine("FromSqlRaw natija: ");
    foreach (var s in studentsRaw)
    {
      Console.WriteLine($"{s.Id}, {s.FullName} - {s.Age}");
    }

    int minAge = 20;
    var studentsInterpolated = context.Students.FromSqlInterpolated($"SELECT * FROM \"Students\" WHERE \"Age\" >= {minAge}")
    .ToList();

    Console.WriteLine("FromSqlInterpolated natija (20 yoshdan katta): ");
    foreach (var s in studentsInterpolated)
      Console.WriteLine($"{s.FullName} ({s.Age})");

    context.Database.ExecuteSqlRaw(
      "INSERT INTO \"Students\" (\"FullName\", \"Age\") VALUES ('Aziza Karimova', 23)"
    );
    Console.WriteLine("ExecuteSqlRaw: Aziza qo'shildi");

    string newName = "Dilshod Toshpulatov";
    int newAge = 21;
    context.Database.ExecuteSqlInterpolated(
      $"INSERT INTO \"Students\" (\"FullName\", \"Age\") VALUES ({newName}, {newAge})"
    );
    Console.WriteLine("ExecuteSqlInterpolated: Dilshod qo'shildi");

    context.Database.ExecuteSqlRaw(
      "DELETE FROM \"Students\" WHERE \"FullName\" = 'Ali Valiyev'"
    );
    Console.WriteLine("O'chirildi");

    string deleteName = "Dilshod Toshpulatov";
    context.Database.ExecuteSqlInterpolated(
      $"DELETE FROM \"Students\" WHERE \"FullName\" = {deleteName}"
    );
    Console.WriteLine("ExecuteSqlInterpolated: Dilshod o'chirildi");
  }
}

