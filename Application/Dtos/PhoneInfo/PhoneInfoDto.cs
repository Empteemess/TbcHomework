using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.Dtos.PhoneInfo;

public class PhoneInfoDto
{
    public PhoneTypeEnum PhoneType { get; set; }
    [Length(4,50,ErrorMessage = "Number must be between 4 and 50 characters.")]
    public required string PhoneNumber { get; set; }
}