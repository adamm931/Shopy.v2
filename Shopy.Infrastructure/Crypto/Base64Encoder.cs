using Shopy.Common.Interfaces;
using System;
using System.Text;

namespace Shopy.Infrastructure.Crypto
{
    public class Base64Encoder : IEncoder
    {
        public string Decode(string input)
        {
            var bytes = Convert.FromBase64String(input);

            return Encoding.UTF8.GetString(bytes);
        }

        public string Encode(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);

            return Convert.ToBase64String(bytes);
        }

        public string Encode(byte[] input) => Convert.ToBase64String(input);
    }
}
