using System;
using System.Linq;

public static class CrudOperations
{
  public static void AddStudent()
  {
    using var db = new AppDbContext();
    Console.Write("Ism Familyani kiriting: ");
    string name = Console.ReadLine();

    Console.Write("Yoshni kiriting: ");
    int age = int.Parse(Console.ReadLine());

    var student = new Student { FullName = name, Age = age };
    db.Students.Add(student);
    db.SaveChanges();

    Console.WriteLine("Talaba qo'shildi");
  }

  public static void ShowAllStudents()
  {
    using var db = new AppDbContext();
    var students = db.Students.ToList();

    Console.WriteLine("Barcha talabalar: ");
    foreach (var s in students)
    {
      Console.WriteLine($"{s.Id} - {s.FullName} ({s.Age} yosh)");
    }
  }

  public static void UpdateStudent()
  {
    using var db = new AppDbContext();

    Console.Write("Yangilamoqchi bo'lgan Id: ");
    int id = int.Parse(Console.ReadLine());

    var student = db.Students.Find(id);
    if (student == null)
    {
      Console.WriteLine("Talaba topilmadi");
      return;
    }
    Console.Write("Yangi ism familya: ");
    student.FullName = Console.ReadLine();

    Console.Write("Yangi yosh: ");
    student.Age = int.Parse(Console.ReadLine());

    db.SaveChanges();
    Console.WriteLine("Talaba qo'shildi");
  }

  public static void DeleteStudent()
  {
    using var db = new AppDbContext();

    Console.Write("O'chirmoqchi bo'lgan id ni kiriting: ");
    int id = int.Parse(Console.ReadLine());

    var student = db.Students.Find(id);

    if (student == null)
    {
      Console.WriteLine("Talaba topilmadi");
      return;
    }

    db.Students.Remove(student);
    db.SaveChanges();

    Console.WriteLine("Talaba o'chirildi");
  }
}
