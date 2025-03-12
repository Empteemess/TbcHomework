using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfigurations;

public class PhoneInfoConfig : IEntityTypeConfiguration<PhoneInfo>
{
    public void Configure(EntityTypeBuilder<PhoneInfo> builder)
    {
        builder.Property(pk => pk.Id).ValueGeneratedOnAdd();        
        
        builder
            .HasOne(au => au.ApplicationUser)
            .WithMany(pi => pi.PhoneInfos)
            .HasForeignKey(aui => aui.ApplicationUserid);
    }
}