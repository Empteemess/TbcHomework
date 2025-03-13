using Domain.Entities;

namespace Domain.IRepositories;

public interface IUserRepository
{
    Task<ApplicationUser?> GetUserByIdAsync(int userId);
    IQueryable<ApplicationUser> GetAllApplicationUsers();
}