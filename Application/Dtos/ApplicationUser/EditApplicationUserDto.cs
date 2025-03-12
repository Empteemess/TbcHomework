using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Application.Dtos.PhoneInfo;
using Domain.Enums;

namespace Application.Dtos.ApplicationUser;

public class EditApplicationUserDto
{
    public int UserId { get; set; }
    [DefaultValue("FirstName")]
    [RegularExpression(@"^(?:[a-zA-Z]{2,50}|\u10A0-\u10FF]{2,50})$",
        ErrorMessage = "The first name must be at least 2 and at most 50 characters long," +
                       "It must contain only Georgian or Latin alphabet letters," +
                       "It must not contain both Latin and Georgian letters at the same time.")]
    [MaxLength(50)]
    public string? FirstName { get; set; }

    [DefaultValue("LastName")]
    [RegularExpression(@"^(?:[a-zA-Z]{2,50}|\u10A0-\u10FF]{2,50})$",
        ErrorMessage = "The last name must be at least 2 and at most 50 characters long," +
                       "It must contain only Georgian or Latin alphabet letters," +
                       "It must not contain both Latin and Georgian letters at the same time.")]
    [MaxLength(50)]
    public string? LastName { get; set; }

    public GenderEnum? Gender { get; set; }

    [DefaultValue("PersonalId")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "PersonId must be exact 11 characters length.")]
    public string? PersonalId { get; set; }

    public DateTime? BirthDate { get; set; }
    public string? CityIdentifier { get; set; }
    public string? Image { get; set; }

    public IEnumerable<PhoneInfoDto>? PhoneInfos { get; set; }
}