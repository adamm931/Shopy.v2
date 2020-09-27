using MediatR;
using Shopy.Application.Interfaces;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Auth.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
    {
        private readonly IRepository<User> users;
        private readonly IAuthService authService;

        public RegisterCommandHandler(IRepository<User> users, IAuthService authService)
        {
            this.users = users;
            this.authService = authService;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var credentials = new UserCredentials(command.Username, command.Password);
            var user = new User(command.Email, credentials);

            await users.Add(user);

            return new RegisterCommandResponse
            {
                Token = await authService.GenerateToken(command.Username)
            };
        }
    }
}
