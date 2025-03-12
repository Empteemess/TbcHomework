using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class PhoneInfo
{
    public int Id { get; set; }

    public PhoneTypeEnum PhoneType { get; set; }
    [Length(4,50,ErrorMessage = "Number must be between 4 and 50 characters.")]
    public required string PhoneNumber { get; set; }

    public int ApplicationUserid { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
}