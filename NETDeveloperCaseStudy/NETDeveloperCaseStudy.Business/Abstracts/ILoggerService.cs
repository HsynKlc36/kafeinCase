using System.Runtime.CompilerServices;

namespace NETDeveloperCaseStudy.Business.Abstracts;
/// <summary>
/// Burada ki Logger metotları Developer için oluşturulan loglamalardır ve geliştirici yazdığı ve gerek duyduğu yerlerde bu loglama metotlarını kullanarak olası hataların yönetilmesinde işini kolaylaştıracaktır.
/// </summary>
public interface ILoggerService
{
    void LogInfo(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "");
    void LogWarning(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "");
    void LogError(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "");
    void LogDebug(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "");
}
