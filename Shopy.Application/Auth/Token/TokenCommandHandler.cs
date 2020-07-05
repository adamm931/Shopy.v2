using MediatR;
using Shopy.Application.Interfaces;
using Shopy.Application.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Auth.Token
{
    public class TokenCommandHandler : IRequestHandler<TokenCommand, TokenResponse>
    {
        private readonly IAuthProvider _tokenProvider;

        public TokenCommandHandler(IAuthProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        public async Task<TokenResponse> Handle(TokenCommand command, CancellationToken cancellationToken)
        {
            var response = new TokenResponse();

            if (IsAuthorized(command))
            {
                response.AccessToken = await _tokenProvider.GenerateToken(command.Username);
                response.IsAuthorized = true;
            }

            return response;
        }

        private bool IsAuthorized(TokenCommand command)
            => command.Username.Equals("admin", StringComparison.OrdinalIgnoreCase)
            && command.Password.Equals("admin", StringComparison.OrdinalIgnoreCase);
    }
}
