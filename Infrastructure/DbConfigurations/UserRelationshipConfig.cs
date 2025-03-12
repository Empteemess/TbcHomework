using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfigurations;

public class UserRelationshipConfig : IEntityTypeConfiguration<UserRelationship>
{
    public void Configure(EntityTypeBuilder<UserRelationship> builder)
    {
        builder.Property(pk => pk.Id).ValueGeneratedOnAdd();
        builder.HasIndex(user => new { user.SourceUserId, user.TargetUserId }).IsUnique();

        builder
            .HasOne(uc => uc.SourceUser)
            .WithMany(u => u.Connections)
            .HasForeignKey(uc => uc.SourceUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(uc => uc.TargetUser)
            .WithMany(u => u.ConnectedBy)
            .HasForeignKey(uc => uc.TargetUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}