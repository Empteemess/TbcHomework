namespace Application.Dtos.Relationship;

public class RemoveRelationshipDto
{
    public int SourceUserId { get; set; }
    public int TargetUserId { get; set; }
}