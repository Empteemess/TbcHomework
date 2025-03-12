using Application.Dtos.UserRelationship;
using Domain.Entities;

namespace Application.Mappers;

public static class UserRelationshipMappers
{
    public static IEnumerable<UserRelationship> ToUserRelationships(
        this IEnumerable<UserRelationshipDto> userRelationshipDtos)
    {
        var mappedUserRelationships = userRelationshipDtos
            .Select(us => new UserRelationship
                {
                    SourceUserId = Math.Min(us.UserId1, us.UserId2),
                    TargetUserId = Math.Max(us.UserId1, us.UserId2),
                    ConnectionType = us.ConnectionType
                }
            );

        return mappedUserRelationships;
    }
}