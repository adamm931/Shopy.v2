using Shopy.Application.Interfaces;

namespace Shopy.Application.Auth.Register
{
    public class RegisterCommand : ICommand
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
