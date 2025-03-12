using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbSet<ApplicationUser> _applicationUsers;

    public UserRepository(AppDbContext appDbContext)
    {
        _applicationUsers = appDbContext.Set<ApplicationUser>();
    }

    public async Task<ApplicationUser?> GetUserByIdAsync(int userId)
    {
        var users = await _applicationUsers
            .Include(u => u.Connections)
            .ThenInclude(c => c.TargetUser) 
            .Include(u => u.ConnectedBy)
            .ThenInclude(c => c.SourceUser) 
            .FirstOrDefaultAsync(x => x.Id == userId);
        
        return users;
    }
}