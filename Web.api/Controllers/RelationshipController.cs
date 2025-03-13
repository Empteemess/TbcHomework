using Application.Dtos.Relationship;
using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    [SwaggerOperation
    (
        Summary = "Add Relationship",
        Description = "Add Relationship With source , targetId and ConnectionType",
        OperationId = "AddRelationship"
    )]
    public async Task<IActionResult> AddRelationship(AddRelationshipDto addRelationshipDto)
    {
        await _userRelationshipsService.AddUserRelationship(addRelationshipDto);
        return NoContent();
    }
    
    [HttpDelete]
    [SwaggerOperation
    (
        Summary = "Remove Relationship",
        Description = "Remove Relationship With source and targetId",
        OperationId = "RemoveRelationship"
    )]
    public async Task<IActionResult> RemoveRelationship(RemoveRelationshipDto removeRelationshipDto)
    {
        await _userRelationshipsService.RemoveUserRelationship(removeRelationshipDto);
        return NoContent();
    }
}