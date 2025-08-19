using System.Linq;
using LinqEntity.Data;

namespace LinqEntity.Reports;


public class LinqQueries
{
  private readonly AppDbContext _context;

  public LinqQueries(AppDbContext context)
  {
    _context = context;
  }

  public void GroupByCourses()
  {
    var report = _context.Enrollments
    .GroupBy(e => e.Course.Title)
    .Select(g => new
    {
      Course = g.Key,
      StudentCount = g.Count()
    })
    .ToList();

    foreach (var i in report)
    {
      Console.WriteLine($"{i.Course} => {i.StudentCount} ta talaba bor.");
    }
  }

  public void JoinStudentsCourses()
  {
    var report = _context.Students
      .Join(_context.Enrollments,
            s => s.Id,
            e => e.StudentId,
            (s, e) => new { s.Name, e.Course.Title })
      .ToList();

    foreach (var i in report)
    {
      Console.WriteLine($"{i.Name} - {i.Title}");
    }
  }

  // public void SelectManyExample()
  // {
  //   var report = _context.Students
  //     .SelectMany(s => s.Enrollments,
  //       (s, e) => new { Student = s.Name, Course = e.Course.Title })
  //   .ToList();

  //   foreach (var i in report)
  //   {
  //     Console.WriteLine($"{i.Student} => {i.Course}");
  //   }
  // }

  public void AverageGrade()
  {
    var report = _context.Enrollments
      .GroupBy(e => e.Course.Title)
      .Select(g => new { Course = g.Key, AvgGrade = g.Average(x => x.Grade) })
    .ToList();

    foreach (var i in report)
    {
      Console.WriteLine($"{i.Course} => O'rtacha baho: {i.AvgGrade:F2}");
    }
  }
}
