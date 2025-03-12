using Application.Dtos.ApplicationUser;
using Domain.Entities;

namespace Application.Mappers;

public static class ApplicationUserMappers
{
    public static ApplicationUser ToApplicationUser(this ApplicationUserDto applicationUserDto)
    {
        var mappedApplicationUser = new ApplicationUser
        {
            FirstName = applicationUserDto.FirstName,
            LastName = applicationUserDto.LastName,
            UserName = applicationUserDto.PersonalId,
            PersonalId = applicationUserDto.PersonalId,
            BirthDate = applicationUserDto.BirthDate,
            CityIdentifier = applicationUserDto.CityIdentifier,
            Image = applicationUserDto.Image,
            PhoneInfos = applicationUserDto.PhoneInfos?.ToPhoneInfos().ToList() ?? [],
        };

        return mappedApplicationUser;
    }

    public static ApplicationUser ToUpdateApplicationUser(this ApplicationUser applicationUser,
        EditApplicationUserDto editApplicationUserDto)
    {
        applicationUser.FirstName = editApplicationUserDto.FirstName ?? applicationUser.FirstName;
        applicationUser.LastName = editApplicationUserDto.LastName ?? applicationUser.LastName;
        applicationUser.Gender = editApplicationUserDto.Gender ?? applicationUser.Gender;
        applicationUser.PersonalId = editApplicationUserDto.PersonalId ?? applicationUser.PersonalId;
        applicationUser.BirthDate = editApplicationUserDto.BirthDate ?? applicationUser.BirthDate;
        applicationUser.CityIdentifier = editApplicationUserDto.CityIdentifier ?? applicationUser.CityIdentifier;
        applicationUser.Image = editApplicationUserDto.Image ?? applicationUser.Image;
        applicationUser.PhoneInfos =
            editApplicationUserDto.PhoneInfos?.ToPhoneInfos().ToList() ?? applicationUser.PhoneInfos;

        return applicationUser;
    }
}