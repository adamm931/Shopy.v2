using Shopy.Common;
using System.Collections.Generic;

namespace Shopy.Domain.Entitties.ValueObjects
{
    public class Username : ValueObject<Username>
    {
        public string Value { get; private set; }

        public Username(string value)
        {
            const string usernameRegex = "^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$";

            Param.Ensure.RegexMatch(value, "username", usernameRegex);

            Value = value;
        }

        private Username() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator Username(string value) => new Username(value);
    }
}
