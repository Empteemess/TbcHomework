using Application.Dtos.PhoneInfo;
using Domain.Entities;

namespace Application.Mappers;

public static class PhoneInfoMappers
{
    public static IEnumerable<PhoneInfo> ToPhoneInfos(this IEnumerable<PhoneInfoDto> phoneInfoDto)
    {
        var mappedPhoneInfo = phoneInfoDto
            .Select(ph => new PhoneInfo { PhoneType = ph.PhoneType, PhoneNumber = ph.PhoneNumber });
        
        return mappedPhoneInfo;
    }
    
    public static IEnumerable<PhoneInfoDto> ToPhoneInfosDto(this IEnumerable<PhoneInfo> phoneInfo)
    {
        var mappedPhoneInfo = phoneInfo
            .Select(ph => new PhoneInfoDto() { PhoneType = ph.PhoneType, PhoneNumber = ph.PhoneNumber });
        
        return mappedPhoneInfo;
    }
}