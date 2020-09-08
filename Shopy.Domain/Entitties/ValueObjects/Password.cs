using Shopy.Common;
using Shopy.Common.Interfaces;
using System.Collections.Generic;

namespace Shopy.Domain.Entitties.ValueObjects
{
    public class Password : ValueObject<Password>
    {
        private static readonly IEncryption encryption = ServiceLocator.GetService<IEncryption>();

        private static readonly IEncoder encoder = ServiceLocator.GetService<IEncoder>();

        public const string Regex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";

        public string Salt { get; private set; }

        public string Hash { get; private set; }

        public Password(string password)
        {
            Param.Ensure.NotNullOrEmpty(password, nameof(password));
            Param.Ensure.RegexMatch(password, nameof(password), Regex);

            var salt = encryption.GenerateSalt();
            var hash = encryption.Encrypt(password + salt);

            Salt = encoder.Encode(salt);
            Hash = hash;
        }

        public bool IsMatch(string password)
        {
            var salt = encoder.Decode(Salt);
            var challengeHash = encryption.Encrypt(password + salt);

            return Hash == challengeHash;
        }

        private Password() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Salt;
            yield return Hash;
        }

        public static implicit operator Password(string plainValue) => new Password(plainValue);
    }
}
