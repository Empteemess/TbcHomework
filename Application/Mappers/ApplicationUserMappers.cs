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
            PersonalId = applicationUserDto.PersonalId,
            BirthDate = applicationUserDto.BirthDate,
            CityIdentifier = applicationUserDto.CityIdentifier,
            Image = applicationUserDto.Image,
            PhoneInfos = applicationUserDto.PhoneInfos?.ToPhoneInfos().ToList() ?? [],
            Connections = applicationUserDto.UserRelationships?.ToUserRelationships().ToList() ?? []
        };
        
        return mappedApplicationUser;
    }
}