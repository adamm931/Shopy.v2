using Shopy.Common;
using Shopy.Domain.Entitties.Base;
using Shopy.Domain.Entitties.ValueObjects;

namespace Shopy.Domain.Entitties
{
    public class UserCredentials : AuditEntity
    {
        public Username Username { get; private set; }

        public Password Password { get; private set; }

        public User User { get; private set; }

        public UserCredentials(Username username, Password password)
        {
            Param.Ensure.NotNull(username, nameof(username));
            Param.Ensure.NotNull(password, nameof(password));

            Username = username;
            Password = password;
        }

        private UserCredentials() { }

        public bool Challenge(string username, string password)
        {
            return Username.Value == username && Password.IsMatch(password);
        }
    }
}
