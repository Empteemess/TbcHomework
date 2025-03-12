using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser<int>
{
    [RegularExpression(@"^(?:[a-zA-Z]{2,50}|\u10A0-\u10FF]{2,50})$",
        ErrorMessage = "The first name must be at least 2 and at most 50 characters long," +
                       "It must contain only Georgian or Latin alphabet letters," +
                       "It must not contain both Latin and Georgian letters at the same time.")]
    [MaxLength(50)]
    public required string FirstName { get; set; }
    
    [RegularExpression(@"^(?:[a-zA-Z]{2,50}|\u10A0-\u10FF]{2,50})$",
        ErrorMessage = "The last name must be at least 2 and at most 50 characters long," +
                       "It must contain only Georgian or Latin alphabet letters," +
                       "It must not contain both Latin and Georgian letters at the same time.")]
    [MaxLength(50)]
    public required string LastName { get; set; }
    
    public GenderEnum Gender { get; set; }
    [StringLength(11,MinimumLength = 11,ErrorMessage = "PersonId must be exact 11 characters length.")]
    public required string PersonalId { get; set; }
    public required DateTime BirthDate { get; set; }
    public string? CityIdentifier { get; set; }
    public string? Image { get; set; }

    public ICollection<PhoneInfo>? PhoneInfos { get; set; }
    public ICollection<UserRelationship>? Connections { get; set; } = [];
    public ICollection<UserRelationship>? ConnectedBy { get; set; } = [];
}