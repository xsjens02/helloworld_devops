using System.Diagnostics;
using API.Logging;
using Monitoring;

namespace API.Services;

public class PlanetService
{
    private static PlanetService? _instance;
    
    public static PlanetService Instance
    {
        get { return _instance ??= new PlanetService(); }
    }
    
    private PlanetService() {}
    
    public PlanetResponse GetPlanet()
    {
        using var activity = MonitorService.ActivitySource.StartActivity("PlanetService.GetPlanet");
        Logger.Log(ELogLevel.DEBUG,"Entered GetPlanet-Method in PlanetService");
        
        var planets = new[]
        {
            "Mercury",
            "Venus",
            "Earth",
            "Mars",
            "Jupiter",
            "Saturn",
            "Uranus",
            "Neptune"
        };

        var index = new Random(DateTime.Now.Millisecond).Next(1, planets.Length+1);
        return new PlanetResponse
        {
            Planet = planets[index]
        };
    }
}