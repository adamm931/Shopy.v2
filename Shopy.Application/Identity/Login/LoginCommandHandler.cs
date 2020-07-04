using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using Shopy.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Identity.Login
{
    public class LoginCommandHandler : ShopyRequestHandler<LoginCommand, LoginResponse>
    {
        public LoginCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var response = new LoginResponse
            {
                IsAuthenticated = command.Username == "Admin" && command.Password == "1234"
            };

            return Task.FromResult(response);
        }
    }
}
