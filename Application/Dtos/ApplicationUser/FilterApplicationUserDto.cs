using Application.Dtos.PhoneInfo;
using Domain.Enums;

namespace Application.Dtos.ApplicationUser;

public class FilterApplicationUserDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public GenderEnum Gender { get; set; }
    public required string PersonalId { get; set; }
    public required DateTime BirthDate { get; set; }
    public string? CityIdentifier { get; set; }
    public string? Image { get; set; }
    public IEnumerable<PhoneInfoDto>? PhoneInfos { get; set; }
}