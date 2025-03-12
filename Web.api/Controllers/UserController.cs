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

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetApplicationUserById(int userId)
    {
        var userInfo = await _userService.GetApplicationUserByIdAsync(userId);
        return Ok(userInfo);
    }

    [HttpDelete("{userId:int}")]
    public async Task<IActionResult> RemoveApplicationUser(int userId)
    {
        await _userService.RemoveApplicationUser(userId);
        return NoContent();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddApplicationUser([FromBody] ApplicationUserDto applicationUser)
    {
        await _userService.AddApplicationUserAsync(applicationUser);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> EditApplicationUser([FromBody] EditApplicationUserDto editApplicationUserDto)
    {
        await _userService.EditApplicationUserAsync(editApplicationUserDto);
        return NoContent();
    }

    [HttpPut("image")]
    public async Task<IActionResult> RemoveOrUpdateApplicationUserImage([FromBody] ImageRequestDto imageRequestDto)
    {
        await _userService.RemoveOrAddApplicationUserImageAsync(imageRequestDto);
        return NoContent();
    }
}