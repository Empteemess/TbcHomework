using Application.Dtos.Relationship;
using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.api.Controllers;

[ApiController]
[Route("[controller]")]
public class RelationshipController : ControllerBase
{
    private readonly IUserRelationshipsService _userRelationshipsService;

    public RelationshipController(IUserRelationshipsService userRelationshipsService)
    {
        _userRelationshipsService = userRelationshipsService;
    }

    [HttpPost]
    public async Task<IActionResult> AddRelationship(AddRelationshipDto addRelationshipDto)
    {
        await _userRelationshipsService.AddUserRelationship(addRelationshipDto);
        return NoContent();
    }
    
    [HttpDelete]
    public async Task<IActionResult> RemoveRelationship(RemoveRelationshipDto removeRelationshipDto)
    {
        await _userRelationshipsService.RemoveUserRelationship(removeRelationshipDto);
        return NoContent();
    }
}