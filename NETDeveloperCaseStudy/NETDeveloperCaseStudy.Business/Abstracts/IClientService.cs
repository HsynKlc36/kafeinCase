namespace NETDeveloperCaseStudy.Business.Abstracts;
public interface IClientService
{
 
    /// <summary>
    ///  Bu metot Client nesnesi silme işlemini yapacaktır.
    /// </summary>
    /// <param name="id">silinmek  istenen Client nesnesinin Guid tipinde Id'si</param>
    /// <returns>IResult</returns>
    Task<Result> DeleteAsync(Guid id);

    /// <summary>
    /// Bu metot verilen id ile eşleşen Client nesnesinin gösterilmesinde kullanılmaktadır.
    /// </summary>
    /// <param name="id">detayları getirilmek istenen Client nesnesinin Guid tipinde Id si</param>
    /// <returns>SuccessDataResult<ClientDto>, ErrorDataResult<ClientDto></returns>
    Task<IResult> GetByIdAsync(Guid id);


    /// <summary>
    /// identity id ile kullanıcının bilgilerini getirir.
    /// </summary>
    /// <param name="identityId"></param>
    /// <returns></returns>
    Task<IResult> GetByIdentityId(string identityId);
}
