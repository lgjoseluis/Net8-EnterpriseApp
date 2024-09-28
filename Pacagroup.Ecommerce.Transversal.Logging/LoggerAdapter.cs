using Microsoft.Extensions.Logging;
using WatchDog;

using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Transversal.Logging;

public class LoggerAdapter<T> : IAppLogger<T>
{
    public LoggerAdapter()
    {
    }

    public void LogError(string message, params object[] args)
    {
        WatchLogger.LogError(message);
    }

    public void LogInformation(string message, params object[] args)
    {
        WatchLogger.Log(message);
    }

    public void LogWarning(string message, params object[] args)
    {
        WatchLogger.LogWarning(message);
    }
}
