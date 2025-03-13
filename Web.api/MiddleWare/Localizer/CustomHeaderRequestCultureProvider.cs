using Microsoft.AspNetCore.Localization;

namespace Web.api.MiddleWare.Localizer;

public class CustomHeaderRequestCultureProvider : RequestCultureProvider
{
    public override Task<ProviderCultureResult?> DetermineProviderCultureResult(HttpContext httpContext)
    {
        if (httpContext == null)
            throw new ArgumentNullException(nameof(httpContext));

        var headerValue = httpContext.Request.Headers["Accept-Language"].ToString();
        
        if (string.IsNullOrWhiteSpace(headerValue))
            return Task.FromResult((ProviderCultureResult)null);

        var cultures = headerValue.Split(',')
            .Select(x => x.Split(';').FirstOrDefault()?.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x));

        var firstCulture = cultures.FirstOrDefault();
        if (string.IsNullOrWhiteSpace(firstCulture))
            return Task.FromResult((ProviderCultureResult)null);

        return Task.FromResult(new ProviderCultureResult(firstCulture));
    }
}