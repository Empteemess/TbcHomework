using Application.Dtos.ApplicationUser;

namespace Application.IServices;

public interface IUserService
{
    Task AddApplicationUserAsync(ApplicationUserDto applicationUserDto);
}