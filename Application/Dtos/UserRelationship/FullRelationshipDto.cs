namespace Application.Dtos.UserRelationship;

public class FullRelationshipDto
{
    public int UserId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Image { get; set; }
}