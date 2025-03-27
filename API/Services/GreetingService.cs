using System.Diagnostics;
using Monitoring;
using API.Logging;

namespace API.Services;

public class GreetingService
{
    private static GreetingService? _instance;
    
    public static GreetingService Instance
    {
        get { return _instance ??= new GreetingService(); }
    }
    
    private GreetingService()
    { }
    
    public GreetingResponse Greet(Messages.GreetingRequest request)
    {
        using var activity = MonitorService.ActivitySource.StartActivity("GreetingService.Greet");
        Logger.Log(ELogLevel.DEBUG,"Entered Greet-Method in GreetingService");
        
        var language = request.LanguageCode;
        var greeting = language switch
        {
            "en" => "Hello",
            "es" => "Hola",
            "fr" => "Bonjour",
            "de" => "Hallo",
            "it" => "Ciao",
            "pt" => "Olá",
            "ru" => "Привет",
            "zh" => "你好",
            "ja" => "こんにちは",
            "ar" => "مرحبا",
            "hi" => "नमस्ते",
            "sw" => "Hujambo"
        };
        return new GreetingResponse { Greeting = greeting };
    }
    
    public string[] GetLanguages()
    {
        using var activity = MonitorService.ActivitySource.StartActivity("GreetingService.GetLanguages");
        Logger.Log(ELogLevel.DEBUG,"Entered GetLanguages-Method in GreetingService");
        
        return new [] { "en", "es", "fr", "de", "it", "pt", "ru", "zh", "ja", "ar", "hi", "sw" };
    }
}