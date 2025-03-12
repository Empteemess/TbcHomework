using Domain.Entities;
using Domain.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public UnitOfWork(AppDbContext appDbContext
        ,UserManager<ApplicationUser> userManager)
    {
        _appDbContext = appDbContext;
        UserManager = userManager;
    }

    public UserManager<ApplicationUser> UserManager { get; }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }
}