using MediatR;
using Shopy.Application.Interfaces;
using Shopy.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IAuthService authProvider;

        public LoginCommandHandler(IAuthService authProvider)
        {
            this.authProvider = authProvider;
        }

        public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var isAuthenticated = await authProvider.Authenticate(command.Username, command.Password);

            return isAuthenticated
                ? new LoginResponse { IsAuthenticated = true, Token = await authProvider.GenerateToken(command.Username) }
                : new LoginResponse { IsAuthenticated = false };
        }
    }
}
