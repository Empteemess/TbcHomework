using Application.Dtos.ApplicationUser;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

    [HttpGet]
    [SwaggerOperation
    (
        Summary = "Get All Application User",
        Description = "Get All Application User With Pagination and Filtering",
        OperationId = "GetAllApplicationUser"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Get All Application User", typeof(ApplicationUserDto))]
    public async Task<IActionResult> GetAllApplicationUser([FromQuery] FilterDto filterDto)
    {
        var filteredAppUser = _userService.FilterApplicationUser(filterDto);
        return Ok(filteredAppUser);
    }

    [HttpGet("{userId:int}")]
    [SwaggerOperation
    (
        Summary = "Get Application User By Id",
        Description = "Get ApplicationUser By Id , With Full userInfo ",
        OperationId = "GetApplicationUserById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Get ApplicationUserById", typeof(ApplicationUserDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "ApplicationUserNotFound", typeof(ApplicationUserDto))]
    public async Task<IActionResult> GetApplicationUserById(int userId)
    {
        var userInfo = await _userService.GetApplicationUserByIdAsync(userId);
        return Ok(userInfo);
    }

    [HttpDelete("{userId:int}")]
    [SwaggerOperation
    (
        Summary = "Removes Application User By Id",
        OperationId = "RemoveApplicationUserById"
    )]
    public async Task<IActionResult> RemoveApplicationUser(int userId)
    {
        await _userService.RemoveApplicationUser(userId);
        return NoContent();
    }

    [HttpPost]
    [SwaggerOperation
    (
        Summary = "Add Application User",
        OperationId = "AddApplicationUser"
    )]
    public async Task<IActionResult> AddApplicationUser([FromBody] ApplicationUserDto applicationUser)
    {
        await _userService.AddApplicationUserAsync(applicationUser);
        return NoContent();
    }

    [HttpPut]
    [SwaggerOperation
    (
        Summary = "Edit Application User",
        OperationId = "EditApplicationUser"
    )]
    public async Task<IActionResult> EditApplicationUser([FromBody] EditApplicationUserDto editApplicationUserDto)
    {
        await _userService.EditApplicationUserAsync(editApplicationUserDto);
        return NoContent();
    }

    [HttpPut("image")]
    [SwaggerOperation
    (
        Summary = "Remove or Update Application User",
        Description = "If ImagePath is null, the user image will be set to defaultImage. If ImagePath is provided, the user image will be updated accordingly.",
        OperationId = "RemoveOrUpdateApplicationUser"
    )]
    public async Task<IActionResult> RemoveOrUpdateApplicationUserImage([FromBody] ImageRequestDto imageRequestDto)
    {
        await _userService.RemoveOrAddApplicationUserImageAsync(imageRequestDto);
        return NoContent();
    }
}