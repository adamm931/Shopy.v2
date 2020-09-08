using FluentValidation;
using Shopy.Application.Interfaces;
using Shopy.Application.Validation;

namespace Shopy.Application.Auth.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator(IAuthService authService)
        {
            RuleFor(model => model.Username)
                .SetValidator(RegexValidator.Username)
                .SetValidator(new UniqueUsernameValidator(authService));

            RuleFor(model => model.Password).SetValidator(RegexValidator.Password);
            RuleFor(model => model.Email).SetValidator(RegexValidator.Email);
        }
    }
}
