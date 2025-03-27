using Monitoring;

namespace API.Logging;

public class Logger
{
    public static void Log(ELogLevel logLevel, string msg)
    {
        Action<string> logAction = logLevel switch
        {
            ELogLevel.DEBUG => MonitorService.Log.Debug,
            ELogLevel.INFO => MonitorService.Log.Information,
            ELogLevel.WARN => MonitorService.Log.Warning,
            ELogLevel.ERROR => MonitorService.Log.Error,
            _ => MonitorService.Log.Information  
        };

        logAction(msg);
    }
}