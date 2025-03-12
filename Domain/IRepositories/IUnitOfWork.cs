using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.IRepositories;

public interface IUnitOfWork
{
    UserManager<ApplicationUser> UserManager { get; }
    Task SaveChangesAsync();
}