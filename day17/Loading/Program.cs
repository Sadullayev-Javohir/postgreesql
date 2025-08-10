using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Loading.Data;
using Loading.Models;

class Program
{
  static void Main()
  {
    using var context = new ApplicationDbContext();

    context.Database.Migrate();

    if (!context.Authors.Any())
    {
      var author1 = new Author
      {
        Name = "J.K. Rowling",
        Books = new[]
        {
          new Book { Title = "Harry Potter and the Philosopher's Stone" },
          new Book { Title = "Harry Potter and the Chamber of Secrets" }
        }
      };

      var author2 = new Author
      {
        Name = "George R.R. Martin",
        Books = new[]
        {
          new Book { Title = "A Game of Thrones" },
          new Book { Title = "A Clash of Kings" }
        }
      };

      context.Authors.AddRange(author1, author2);
      context.SaveChanges();

      // Console.WriteLine("Ma'lumotlar qo'shildi");
      var authorsWithBooks = context.Authors
        .Include(a => a.Books)
        .ToList();

      Console.WriteLine("\nEager Loading natijasi");

      foreach (var author in authorsWithBooks)
      {
        Console.WriteLine($"Author: {author.Name}");

        if (author.Books != null)
        {
          foreach (var book in author.Books)
          {
            Console.WriteLine($"Book: {book.Title}");
          }
        }
      }
    }
  }
}
