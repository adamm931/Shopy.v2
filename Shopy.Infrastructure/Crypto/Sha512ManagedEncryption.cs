using Shopy.Common.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Shopy.Infrastructure.Crypto
{
    public class Sha512ManagedEncryption : IEncryption
    {
        private readonly IEncoder encoder;

        public Sha512ManagedEncryption(IEncoder encoder)
        {
            this.encoder = encoder;
        }

        public string Encrypt(string value)
        {
            var algoritm = new SHA512Managed();
            var hash = algoritm.ComputeHash(Encoding.UTF8.GetBytes(value));

            return encoder.Encode(hash);
        }

        public string GenerateSalt() => Guid.NewGuid().ToString().Replace("-", string.Empty);
    }
}
