using Microsoft.EntityFrameworkCore;
using MigrationMain.Models;
using MigrationMain.Data;

public class Program
{
  public static void Main()
  {
    using var context = new AppDbContext();

    context.Students.Add(new Student { FullName = "Ali Karimov" });
    context.SaveChanges();

    Console.WriteLine("Student saqlandi");
  }
}
