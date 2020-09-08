using FluentValidation;
using Shopy.Application.Validation;

namespace Shopy.Application.Auth.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(command => command.Username).SetValidator(RegexValidator.Username);
            RuleFor(command => command.Password).SetValidator(RegexValidator.Password);
        }
    }
}
