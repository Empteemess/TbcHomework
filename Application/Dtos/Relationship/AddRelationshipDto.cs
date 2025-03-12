using Domain.Enums;

namespace Application.Dtos.Relationship;

public class AddRelationshipDto
{
    public int SourceUserId { get; set; }
    public int TargetUserId { get; set; }
    public ConnectionTypeEnum ConnectionType { get; set; }
}