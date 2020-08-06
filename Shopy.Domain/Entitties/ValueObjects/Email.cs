using Shopy.Common;
using System.Collections.Generic;

namespace Shopy.Domain.Entitties.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            const string emailRegex = @"^\S+@\S+$";

            Param.Ensure.RegexMatch(value, "username", emailRegex);

            Value = value;
        }

        private Email() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator Email(string value) => new Email(value);
    }
}
