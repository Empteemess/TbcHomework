using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Web.api.MiddleWare.Localizer;

namespace Web.api.Configurations;

public static class LocalizationConfig
{
    public static IServiceCollection AddLocalizationConfig(this IServiceCollection services)
    {
        services.AddLocalization();

        services.AddSingleton<JsonLocalizationService>();

        services.AddRequestLocalization(options =>
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("ka-GE")
            };

            options.DefaultRequestCulture = new RequestCulture("en-US");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;

            options.RequestCultureProviders.Insert(0, new CustomHeaderRequestCultureProvider());
        });

        return services;
    }
}