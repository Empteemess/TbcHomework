using Application.Dtos.ApplicationUser;
using Application.IServices;
using Application.Mappers;
using Domain.CustomExceptions;
using Domain.IRepositories;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddApplicationUserAsync(ApplicationUserDto applicationUserDto)
    {
        var applicationUser = applicationUserDto.ToApplicationUser();
        
        if(applicationUser is null) throw new IdentityException("Application user is null");

        await _unitOfWork.UserManager.CreateAsync(applicationUser);
    }
}