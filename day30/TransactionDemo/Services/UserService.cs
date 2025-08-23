using TransactionDemo.Data;
using TransactionDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace TransactionDemo.Services;

public class UserService
{
  private readonly AppDbContext _context;

  public UserService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<bool> CreateUsersWithTransaction()
  {
    using var transaction = await _context.Database.BeginTransactionAsync();
    try
    {
      _context.Users.Add(new User { Name = "Ali", Email = "ali@example.com" });
      await _context.SaveChangesAsync();

      _context.Users.Add(new User { Name = "Vali", Email = "vali@example.com" });
      await _context.SaveChangesAsync();

      await transaction.CommitAsync();
      return true;
    }
    catch
    {
      await transaction.RollbackAsync();
      return false;
    }

  }
}
