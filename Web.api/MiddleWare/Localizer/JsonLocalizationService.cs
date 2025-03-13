using System.Text.Json;

namespace Web.api.MiddleWare.Localizer;

public class JsonLocalizationService
{
     private readonly IWebHostEnvironment _environment;
    private readonly Dictionary<string, Dictionary<string, string>> _localizations;

    public JsonLocalizationService(IWebHostEnvironment environment)
    {
        _environment = environment;
        _localizations = new Dictionary<string, Dictionary<string, string>>();
        LoadLocalizations();
    }

    private void LoadLocalizations()
    {
        var resourcesPath = Path.Combine(_environment.ContentRootPath, "Resources");
        
        foreach (var cultureFolder in Directory.GetDirectories(resourcesPath))
        {
            var cultureName = Path.GetFileName(cultureFolder);
            
            foreach (var jsonFile in Directory.GetFiles(cultureFolder, "*.json"))
            {
                var controller = Path.GetFileNameWithoutExtension(jsonFile);
                var localizationKey = $"{cultureName}_{controller}";
                
                var jsonContent = File.ReadAllText(jsonFile);
                var resourceDictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);
                
                if (resourceDictionary != null)
                {
                    _localizations[localizationKey] = resourceDictionary;
                }
            }
        }
    }

    public string GetLocalizedString(string controller, string key, string culture)
    {
        var localizationKey = $"{culture}_{controller}";
        
        if (_localizations.TryGetValue(localizationKey, out var resources) && 
            resources.TryGetValue(key, out var value))
        {
            return value;
        }
        
        localizationKey = $"en-US_{controller}";
        if (_localizations.TryGetValue(localizationKey, out resources) && 
            resources.TryGetValue(key, out value))
        {
            return value;
        }
        
        return key; 
    }
}
