using EfMigrationDemo.Models;
using EfMigrationDemo.Data;
class Program
{
  static void Main()
  {
    using var context = new AppDbContext();

    var student = new Student { Name = "Ali" };

    context.Students.Add(student);

    context.SaveChanges();

    
  }
}
