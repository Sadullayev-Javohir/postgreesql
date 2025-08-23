using Microsoft.AspNetCore.Mvc;
using TransactionApp.Services;

namespace TransactionApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
  private readonly UserService _service;
  public UsersController(UserService service) => _service = service;

  [HttpPost("create-many")]
  public async Task<IActionResult> CreateMany()
  {
    var success = await _service.CreateUsersWithTransaction();
    return success ? Ok("Transaction Success") : BadRequest("Transaction Failed");
  }
}
