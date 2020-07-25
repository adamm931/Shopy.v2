using MediatR;
using Shopy.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var response = new LoginResponse
            {
                IsAuthenticated = command.Username == "Admin" && command.Password == "Admin"
            };

            return await Task.FromResult(response);
        }
    }
}
