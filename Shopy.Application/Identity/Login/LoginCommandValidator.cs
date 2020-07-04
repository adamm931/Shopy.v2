using FluentValidation;
using Shopy.Application.Validation;

namespace Shopy.Application.Identity.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(command => command.Username)
                .NotEmpty()
                .WithValidationMessageCode(ValidationCode.Empty);

            RuleFor(command => command.Password)
                .NotEmpty()
                .WithValidationMessageCode(ValidationCode.Empty);
        }
    }
}
