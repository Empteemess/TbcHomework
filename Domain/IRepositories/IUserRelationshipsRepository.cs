using Domain.Enums;

namespace Domain.IRepositories;

public interface IUserRelationshipsRepository
{
    void RemoveRelationshipBySourceId(int sourceUserId);
    Task RemoveRelationshipAsync(int sourceUserId, int targetUserId);
    Task<bool> CheckIfRelationshipExistsAsync(int sourceUserId, int targetUserId);
    Task AddRelationshipAsync(int sourceUserId, int targetUserId, ConnectionTypeEnum connectionType);
}