using System.Security.Cryptography;
using System;

namespace Hermes.Identity.Services
{
    public class Encrypter : IEncrypter
    {

        private static readonly int SaltSize = 40;

        private static readonly int DriveBytesIterationCount = 10000;

        public string GetSalt(string value)
        {
            var random = new Random();
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            var pbk = new Rfc2898DeriveBytes(value, GetBytes(salt), DriveBytesIterationCount);
            return Convert.ToBase64String(pbk.GetBytes(SaltSize));
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}