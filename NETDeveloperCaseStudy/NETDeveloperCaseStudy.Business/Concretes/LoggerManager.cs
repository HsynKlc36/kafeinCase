using NLog;
using System.Runtime.CompilerServices;

namespace NETDeveloperCaseStudy.Business.Concretes;
public class LoggerManager : ILoggerService
{

    private static NLog.ILogger _logger = LogManager.GetCurrentClassLogger();
    public void LogDebug(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
    {
        var callsite = $"{Path.GetFileName(filePath)}.{memberName}";
        _logger.Debug($"{callsite} - Message: {message}");
    }

    public void LogError(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
    {
        var callsite = $"{Path.GetFileName(filePath)}.{memberName}";
        _logger.Error($"{callsite} - Message: {message}");
    }

    public void LogInfo(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
    {
        var callsite = $"{Path.GetFileName(filePath)}.{memberName}";
        _logger.Info($"{callsite} - Message: {message}");
    }

    public void LogWarning(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
    {
        var callsite = $"{Path.GetFileName(filePath)}.{memberName}";
        _logger.Warn($"{callsite} - Message: {message}");
    }

}
