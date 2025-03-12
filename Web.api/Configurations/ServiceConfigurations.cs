using System.Text.Json.Serialization;
using Application.IServices;
using Application.Services;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Web.api.MiddleWare;

namespace Web.api.Configurations;

public static class ServiceConfigurations
{
    public static IServiceCollection AddServiceConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<UserManager<ApplicationUser>>();
        services.AddScoped<IUserService,UserService>();
        services.AddScoped<IStorageService,StorageService>();
        
        services.AddScoped<ErrorHandlingMiddleware>();
        
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        
        return services;
    }
}