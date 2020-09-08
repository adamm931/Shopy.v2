using MediatR;
using Shopy.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Auth.CheckUsername
{
    public class CheckUsernameHandler : IRequestHandler<CheckUsernameCommand, CheckUsernameResponse>
    {
        private readonly IAuthService authService;

        public CheckUsernameHandler(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<CheckUsernameResponse> Handle(CheckUsernameCommand request, CancellationToken cancellationToken)
            => new CheckUsernameResponse
            {
                IsAvailable = await authService.CheckUsername(request.Username)
            };
    }
}
