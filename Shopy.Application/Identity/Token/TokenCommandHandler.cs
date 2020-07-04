using MediatR;
using Shopy.Application.Interfaces;
using Shopy.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Identity.Token
{
    public class TokenCommandHandler : IRequestHandler<TokenCommand, TokenResponse>
    {
        private readonly ITokenProvider _tokenProvider;

        public TokenCommandHandler(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        public async Task<TokenResponse> Handle(TokenCommand command, CancellationToken cancellationToken)
        {
            var tokenResponse = new TokenResponse();

            // TODO: replace this with logic
            if (command.Username != "admin" || command.Password != "admin")
            {
                return await Task.FromResult(tokenResponse);
            }

            tokenResponse.AccessToken = await _tokenProvider.GenerateToken(command.Username, command.Password);

            return tokenResponse;
            ;
        }
    }
}
