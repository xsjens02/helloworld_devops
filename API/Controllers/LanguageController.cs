using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using API.Logging;
using Monitoring;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguageController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        using var activity = MonitorService.ActivitySource.StartActivity("LanguageController.Get");
        Logger.Log(ELogLevel.DEBUG, "Entered Get-Method in LanguageController");
            
        var language = LanguageService.Instance.GetLanguages();
        return Ok(new GetLanguageModel.Response { DefaultLanguage = language.DefaultLanguage, Languages = language.Languages });
    }
}