using Application.Dtos.ApplicationUser;

namespace Application.IServices;

public interface IUserService
{
    Task RemoveApplicationUser(int userId);
    Task AddApplicationUserAsync(ApplicationUserDto applicationUserDto);
    Task RemoveOrAddApplicationUserImageAsync(ImageRequestDto imageRequestDto);
    Task EditApplicationUserAsync(EditApplicationUserDto editApplicationUserDto);
}