using Shopy.Common;
using System.Collections.Generic;

namespace Shopy.Domain.Entitties.ValueObjects
{
    public class Username : ValueObject<Username>
    {
        public const string Regex = "^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$";

        public string Value { get; private set; }

        public Username(string value)
        {
            Param.Ensure.RegexMatch(value, "username", Regex);

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
