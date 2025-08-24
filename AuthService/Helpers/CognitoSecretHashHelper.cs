using System.Security.Cryptography;
using System.Text;

namespace AuthService.Helpers
{
    public class CognitoSecretHashHelper
    {
        public static string GenerateSecretHash(string username, string clientId, string clientSecret)
        {
            var keyBytes = Encoding.UTF8.GetBytes(clientSecret);
            var message = Encoding.UTF8.GetBytes(username + clientId);

            using (var hmac = new HMACSHA256(keyBytes))
            {
                var hash = hmac.ComputeHash(message);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
