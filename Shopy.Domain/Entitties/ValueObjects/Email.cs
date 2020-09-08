using Shopy.Common;
using System.Collections.Generic;

namespace Shopy.Domain.Entitties.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public const string Regex = @"^\S+@\S+$";

        public string Value { get; private set; }

        public Email(string value)
        {
            Param.Ensure.RegexMatch(value, "username", Regex);

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
