using Microsoft.AspNetCore.Localization;

namespace Web.api.MiddleWare.Localizer;

public class JsonLocalizer
{
    private readonly JsonLocalizationService _localizationService;
    private readonly string _controller;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public JsonLocalizer(
        JsonLocalizationService localizationService, 
        string controller,
        IHttpContextAccessor httpContextAccessor)
    {
        _localizationService = localizationService;
        _controller = controller;
        _httpContextAccessor = httpContextAccessor;
    }

    public string this[string key]
    {
        get
        {
            var culture = _httpContextAccessor.HttpContext?.Features
                .Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name ?? "en-US";
            
            return _localizationService.GetLocalizedString(_controller, key, culture);
        }
    }
}