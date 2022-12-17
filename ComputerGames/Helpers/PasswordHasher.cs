using System.Security.Cryptography;
using System.Text;

namespace ComputerGames.Helpers
{
    public class PasswordHasher
    {
       // Хеширование пароля
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var HashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(HashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}
