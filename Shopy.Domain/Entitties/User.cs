using Shopy.Common;
using Shopy.Domain.Entitties.Base;
using Shopy.Domain.Entitties.ValueObjects;

namespace Shopy.Domain.Entitties
{
    public class User : AuditEntity
    {
        public UserPerson Person { get; private set; }

        public Email Email { get; private set; }

        public UserCredentials Credentials { get; private set; }

        public User(UserPerson person, Email email, UserCredentials credentials)
        {
            UpdatePerson(person);
            UpdateEmail(email);
            UpdateCredentials(credentials);
        }

        public User(Email email, UserCredentials credentials)
        {
            UpdateEmail(email);
            UpdateCredentials(credentials);
        }

        private User() { }

        public void UpdateEmail(Email email)
        {
            Param.Ensure.NotNull(email, nameof(email));

            Email = email;
        }

        public void UpdatePerson(UserPerson person)
        {
            Param.Ensure.NotNull(person, nameof(person));

            Person = person;
        }

        public void UpdateCredentials(UserCredentials credentials)
        {
            Param.Ensure.NotNull(credentials, nameof(credentials));

            Credentials = credentials;
        }
    }
}
