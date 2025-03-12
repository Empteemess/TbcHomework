using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Web.api.Configurations;

public static class DbConfigurations
{
    public static IServiceCollection AddDbConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt => opt
            .UseSqlServer(configuration["DB_CONNECTION_STRING"]));
        
        services.AddIdentity<ApplicationUser,IdentityRole<int>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}