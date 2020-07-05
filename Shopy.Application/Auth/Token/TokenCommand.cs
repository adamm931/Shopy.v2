using MediatR;
using Shopy.Application.Models;

namespace Shopy.Application.Auth.Token
{
    public class TokenCommand : IRequest<TokenResponse>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
