namespace Application.Dtos.ApplicationUser;

public class ImageRequestDto
{
    public required int UserId { get; set; }
    public string? ImagePath { get; set; }
}