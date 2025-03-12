using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.IRepositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IUserRelationshipsRepository UserRelationshipsRepository { get; }
    UserManager<ApplicationUser> UserManager { get; }
    Task SaveChangesAsync();
}