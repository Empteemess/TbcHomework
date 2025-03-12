using Domain.Entities;
using Domain.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public UnitOfWork(AppDbContext appDbContext
        ,UserManager<ApplicationUser> userManager,
        IUserRelationshipsRepository userRelationshipsRepository)
    {
        _appDbContext = appDbContext;
        UserManager = userManager;
        UserRelationshipsRepository = userRelationshipsRepository;
    }

    public IUserRelationshipsRepository UserRelationshipsRepository { get; }
    public UserManager<ApplicationUser> UserManager { get; }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }
}