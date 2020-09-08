using MediatR;

namespace Shopy.Application.Auth.CheckUsername
{
    public class CheckUsernameCommand : IRequest<CheckUsernameResponse>
    {
        public string Username { get; set; }
    }
}
