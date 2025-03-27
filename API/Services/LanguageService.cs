using Messages;
using API.Logging;
using Monitoring;

namespace API.Services;

public class LanguageService
{
    private static LanguageService? _instance;
    
    public static LanguageService Instance
    {
        get { return _instance ??= new LanguageService(); }
    }
    
    private LanguageService()
    { }
    
    public LanguageResponse GetLanguages()
    {
        using var activity = MonitorService.ActivitySource.StartActivity("LanguageService.GetLanguages");
        Logger.Log(ELogLevel.DEBUG, "Entered GetLanguages-Method in LanguageService");
        
        return new LanguageResponse
        {
            Languages = GreetingService.Instance.GetLanguages()
        };
    }
}