using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.IRepositories;

public interface IUnitOfWork
{
    IUserRelationshipsRepository UserRelationshipsRepository { get; }
    UserManager<ApplicationUser> UserManager { get; }
    Task SaveChangesAsync();
}