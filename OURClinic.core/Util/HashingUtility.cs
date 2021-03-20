using System;
using System.Security.Cryptography;
using System.Text;

namespace OURCart.Core.Util
{
    public static class HashingUtility
    {
        public static string hashPassword(string pass)
        {
            string hash = "";
            // SHA256 is disposable by inheritance.  
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
                // Get the hashed string.  
                hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                // Print the string.   
            }
            return hash;
        }
    }
}
