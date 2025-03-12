using Domain.Enums;

namespace Application.Dtos.UserRelationship;

public class UserRelationshipDto
{
    public int UserId1 { get; set; }
    public int UserId2 { get; set; }
    public required ConnectionTypeEnum ConnectionType { get; set; }
}