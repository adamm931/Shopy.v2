using Shopy.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Shopy.Domain.Entitties.ValueObjects
{
    public class UserPerson : ValueObject<UserPerson>
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string MiddleName { get; private set; }

        public string FullName => Regex.Replace($"{FirstName} {MiddleName} {LastName}", " {2,}", " ");

        public UserPerson(string firstName, string lastName, string middleName = null)
        {
            Param.Ensure.NotNullOrEmpty(firstName, nameof(firstName));
            Param.Ensure.NotNullOrEmpty(lastName, nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        private UserPerson() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return MiddleName;
        }
    }
}
