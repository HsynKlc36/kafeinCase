using System.Security.Cryptography;

namespace NETDeveloperCaseStudy.Business.Password;
public  class PasswordHasher
{
    public static string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashedPassword = Convert.ToBase64String(bytes);
            return hashedPassword;
        }
    }
}
