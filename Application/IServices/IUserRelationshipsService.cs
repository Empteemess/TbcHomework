using Application.Dtos.Relationship;

namespace Application.IServices;

public interface IUserRelationshipsService
{
    Task AddUserRelationship(AddRelationshipDto addRelationshipDto);
    Task RemoveUserRelationship(RemoveRelationshipDto removeRelationshipDto);
}