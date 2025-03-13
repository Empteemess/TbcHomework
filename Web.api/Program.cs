using DotNetEnv;
using Web.api.Configurations;
using Web.api.MiddleWare;

namespace Web.api;

public class Program
{
    public static void Main(string[] args)
    {
        Env.Load();
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddEnvironmentVariables();

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddDbConfigurations(builder.Configuration);
        
        builder.Services.AddServiceConfigurations();
        builder.Services.AddSwaggerConfigs();
        builder.Services.AddLocalizationConfig();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseHttpsRedirection();
        
        app.UseRequestLocalization();
        
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}