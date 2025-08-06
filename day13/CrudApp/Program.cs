using System;

class Program
{
  static void Main()
  {
    while (true)
    {
      Console.WriteLine("\n=== CRUD Dasturi ===");
      Console.WriteLine("1. Talaba qo‘shish");
      Console.WriteLine("2. Barcha talabalarni ko‘rish");
      Console.WriteLine("3. Talabani yangilash");
      Console.WriteLine("4. Talabani o‘chirish");
      Console.WriteLine("0. Chiqish");
      Console.Write("Tanlang: ");

      var choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          CrudOperations.AddStudent();
          break;
        case "2":
          CrudOperations.ShowAllStudents();
          break;
        case "3":
          CrudOperations.UpdateStudent();
          break;
        case "4":
          CrudOperations.DeleteStudent();
          break;
        case "0":
          Console.WriteLine("Dastur yakunlandi");
          return;
        default:
          Console.WriteLine("Noto'g'ri tanlov");
          break;
      }
    }
  }
}
