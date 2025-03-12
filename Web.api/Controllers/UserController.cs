using Application.Dtos.ApplicationUser;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Web.api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> AddApplicationUser([FromBody] ApplicationUserDto applicationUser)
    {
        await _userService.AddApplicationUserAsync(applicationUser);
        return NoContent();
    }
}