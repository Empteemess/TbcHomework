using Domain.Entities;
using Infrastructure.DbConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser,IdentityRole<int>,int>   
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<PhoneInfo> PhoneInfos { get; set; }
    public DbSet<UserRelationship> UserRelationships { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new PhoneInfoConfig());
        builder.ApplyConfiguration(new ApplicationUserConfig());
        builder.ApplyConfiguration(new UserRelationshipConfig());
    }
}