namespace NETDeveloperCaseStudy.Business.Abstracts;

public interface ITokenBlackListService
{
   /// <summary>
   /// Çıkış yapan userın tokenını blackliste atmak için kullanılır
   /// </summary>
   /// <param name="token"></param>
   /// <returns></returns>
    Task<bool> CreateAsync(string token);
}
