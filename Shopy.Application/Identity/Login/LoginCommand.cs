using MediatR;
using Shopy.Application.Models;

namespace Shopy.Application.Identity.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
