using System.Net;
using Application.Dtos.ApplicationUser;
using Application.IServices;
using Application.Mappers;
using Domain.CustomExceptions;
using Domain.Entities;
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

    public async Task EditApplicationUserAsync(EditApplicationUserDto editApplicationUserDto)
    {
        if(editApplicationUserDto is null) throw new IdentityException("You must update minimum One Field");
        
        var applicationUser = await _unitOfWork.UserManager.FindByIdAsync($"{editApplicationUserDto.UserId}");

        if(applicationUser is null) throw new IdentityException("Application",(int)HttpStatusCode.NotFound);

        var mappedApplicationUser = applicationUser.ToUpdateApplicationUser(editApplicationUserDto);
        
        await _unitOfWork.UserManager.UpdateAsync(mappedApplicationUser);
    }
}