using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace EX3A_Encypt_Auth
{
    public class Hasher
    {
        public static string CreateHash(string plaintext)
        {
            string hashValue = null;
            // Encoding the plaintext string as a Byte array
            var enc = new UTF32Encoding();
            Byte[] encodedBytes = enc.GetBytes(plaintext);

            // Compute the hash of the plaintext byte array
            using (SHA256 mySHA256 = SHA256.Create())
            {
                encodedBytes = mySHA256.ComputeHash(encodedBytes);
                hashValue = Convert.ToBase64String(encodedBytes);
            }
            return hashValue;
        }
    }
}