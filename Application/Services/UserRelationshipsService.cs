using System.Net;
using Application.Dtos.Relationship;
using Application.IServices;
using Domain.CustomExceptions;
using Domain.IRepositories;

namespace Application.Services;

public class UserRelationshipsService : IUserRelationshipsService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserRelationshipsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddUserRelationship(AddRelationshipDto addRelationshipDto)
    {
        await UserCheckerAsync(addRelationshipDto.SourceUserId, addRelationshipDto.TargetUserId);

        var relationshipExists = await RelationshipExistsAsync(addRelationshipDto.SourceUserId, addRelationshipDto.TargetUserId);

        if (relationshipExists) throw new IdentityException("User relationship already exists");

        await _unitOfWork.UserRelationshipsRepository.AddRelationshipAsync(addRelationshipDto.SourceUserId,
            addRelationshipDto.TargetUserId, addRelationshipDto.ConnectionType);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveUserRelationship(RemoveRelationshipDto removeRelationshipDto)
    {
        await UserCheckerAsync(removeRelationshipDto.SourceUserId, removeRelationshipDto.TargetUserId);

        var relationshipExists = await RelationshipExistsAsync(removeRelationshipDto.SourceUserId, removeRelationshipDto.TargetUserId);

        if (!relationshipExists) throw new IdentityException("User Relationship does not exist");

        await _unitOfWork.UserRelationshipsRepository.RemoveRelationshipAsync(removeRelationshipDto.SourceUserId,
            removeRelationshipDto.TargetUserId);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task<bool> RelationshipExistsAsync(int sourceUserId, int targetUserId)
    {
        var relationshipExists =
            await _unitOfWork.UserRelationshipsRepository.CheckIfRelationshipExistsAsync(sourceUserId, targetUserId);

        return relationshipExists;
    }

    private async Task UserCheckerAsync(int sourceUserId, int targetUserId)
    {
        var sourceUser = await _unitOfWork.UserManager.FindByIdAsync($"{sourceUserId}");

        if (sourceUser is null)
            throw new IdentityException($"{sourceUserId}", (int)HttpStatusCode.NotFound);

        var targetUser = await _unitOfWork.UserManager.FindByIdAsync($"{targetUserId}");

        if (targetUser is null)
            throw new IdentityException($"{targetUserId}", (int)HttpStatusCode.NotFound);
    }
}