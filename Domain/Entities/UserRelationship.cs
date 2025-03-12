using Domain.Enums;

namespace Domain.Entities;

public class UserRelationship
{
    public int Id { get; set; }

    public required int SourceUserId { get; set; }
    public ApplicationUser? SourceUser { get; set; }
    
    public required int TargetUserId { get; set; }
    public ApplicationUser? TargetUser { get; set; }

    public required ConnectionTypeEnum ConnectionType { get; set; }
}