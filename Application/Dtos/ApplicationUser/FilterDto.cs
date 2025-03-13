using System.ComponentModel;

namespace Application.Dtos.ApplicationUser;

public class FilterDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PersonalId { get; set; }
    [DefaultValue(1)]
    public int QurrentPage { get; set; }
    [DefaultValue(4)]
    public int UserQuantity { get; set; }
}