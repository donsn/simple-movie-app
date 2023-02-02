using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
namespace MovieMaster.Tools
{
    public static class PasswordHasher
	{

        const int keySize = 32;
        const int iterations = 100000;
        static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
        const char segmentDelimiter = ':';

        private const int saltSize = 16;


        /// <summary>
        /// Verify the user's password
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hashString"></param>
        /// <returns></returns>
        public static bool VerifyPassword(string input, string hashString)
        {
            string[] segments = hashString.Split(segmentDelimiter);
            if (segments.Count() < 2)
            {
                return false;
            }
            byte[] hash = Convert.FromHexString(segments[0]);
            byte[] salt = Convert.FromHexString(segments[1]);
            int iterations = int.Parse(segments[2]);
            HashAlgorithmName algorithm = new HashAlgorithmName(segments[3]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
                input,
                salt,
                iterations,
                algorithm,
                hash.Length
            );
            return CryptographicOperations.FixedTimeEquals(inputHash, hash);
        }

        /// <summary>
        /// Hash password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPasword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(saltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iterations,
            hashAlgorithm,
                keySize);
            return string.Join(
                segmentDelimiter,
                Convert.ToHexString(hash),
                Convert.ToHexString(salt),
                iterations,
                hashAlgorithm
            );
        }
    }
}

