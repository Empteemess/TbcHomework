using Domain.Entities;
using Domain.Enums;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRelationshipsRepository : IUserRelationshipsRepository
{
    private readonly DbSet<UserRelationship> _userRelationships;

    public UserRelationshipsRepository(AppDbContext appDbContext)
    {
        _userRelationships = appDbContext.Set<UserRelationship>();
    }

    public async Task AddRelationshipAsync(int sourceUserId, int targetUserId, ConnectionTypeEnum connectionType)
    {
        var userRelation = new UserRelationship
        {
            ConnectionType = connectionType,
            SourceUserId = sourceUserId,
            TargetUserId = targetUserId
        };

        await _userRelationships.AddAsync(userRelation);
    }

    public async Task<bool> CheckIfRelationshipExistsAsync(int sourceUserId, int targetUserId)
    {
        var userRelation =
            await _userRelationships.FirstOrDefaultAsync(x =>
                x.SourceUserId == sourceUserId && x.TargetUserId == targetUserId);

        if (userRelation is null) return false;
        
        return true;
    }

    public async Task RemoveRelationshipAsync(int sourceUserId, int targetUserId)
    {
        var userRelation =
            await _userRelationships.FirstOrDefaultAsync(x =>
                x.SourceUserId == sourceUserId && x.TargetUserId == targetUserId);

        _userRelationships.Remove(userRelation!);
    }
    
    public void RemoveRelationshipBySourceId(int sourceUserId)
    {
        var userRelation = _userRelationships.Where(x => x.SourceUserId == sourceUserId || x.TargetUserId == sourceUserId);

        _userRelationships.RemoveRange(userRelation);
    }
}