using MediatR;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Auth.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IRepository<User> users;

        public RegisterCommandHandler(IRepository<User> users)
        {
            this.users = users;
        }

        public async Task<Unit> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var credentials = new UserCredentials(command.Username, command.Password);
            var user = new User(command.Email, credentials);

            await users.Add(user);

            return Unit.Value;
        }
    }
}
