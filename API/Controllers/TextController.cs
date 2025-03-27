using System.Diagnostics;
using API.Logging;
using API.Models;
using API.Services;
using Messages;
using Microsoft.AspNetCore.Mvc;
using Monitoring;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TextController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string languageCode)
    {
        using var activity = MonitorService.ActivitySource.StartActivity("TextController.Get");
        Logger.Log(ELogLevel.DEBUG,"Entered Get-Method in TextController");
        
        try
        {
            var greeting = GreetingService.Instance.Greet(new GreetingRequest { LanguageCode = languageCode });
            var planet = PlanetService.Instance.GetPlanet();
        
            var response = new GetGreetingModel.Response
            {
                Greeting = greeting.Greeting,
                Planet = planet.Planet
            };
            return Ok(response);
        }
        catch (Exception e)
        {
            Logger.Log(ELogLevel.ERROR, $"Error occurred in Get-Method in TextController: {e.Message}");
            return StatusCode(500, "An error occurred");
        }
        finally
        {
            activity?.Stop(); 
        }
    }
}