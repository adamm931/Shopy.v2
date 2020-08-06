using MediatR;
using Shopy.Application.Interfaces;
using Shopy.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Auth.Token
{
    public class TokenCommandHandler : IRequestHandler<TokenCommand, TokenResponse>
    {
        private readonly IAuthProvider authProvider;

        public TokenCommandHandler(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        public async Task<TokenResponse> Handle(TokenCommand command, CancellationToken cancellationToken)
        {
            var response = new TokenResponse();

            if (await authProvider.Authenticate(command.Username, command.Password))
            {
                response.AccessToken = await authProvider.GenerateToken(command.Username);
                response.IsAuthenticated = true;
            }

            return response;
        }
    }
}
