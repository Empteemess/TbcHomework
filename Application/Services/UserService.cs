using System.Net;
using Application.Dtos.ApplicationUser;
using Application.IServices;
using Application.Mappers;
using Domain.CustomExceptions;
using Domain.IRepositories;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public UserService(IUnitOfWork unitOfWork,IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
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

    public async Task RemoveOrAddApplicationUserImageAsync(ImageRequestDto imageRequestDto)
    {
        var applicationUser = await _unitOfWork.UserManager.FindByIdAsync($"{imageRequestDto.UserId}");
        
        if(applicationUser is null) throw new IdentityException("Application",(int)HttpStatusCode.NotFound);
        
        applicationUser.Image = imageRequestDto.ImagePath ?? _configuration["DEFAULT_IMAGE"];
        
        await _unitOfWork.UserManager.UpdateAsync(applicationUser);
    }
}