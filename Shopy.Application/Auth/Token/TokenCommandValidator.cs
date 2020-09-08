using FluentValidation;
using Shopy.Application.Validation;

namespace Shopy.Application.Auth.Token
{
    public class TokenCommandValidator : AbstractValidator<TokenCommand>
    {
        public TokenCommandValidator()
        {
            RuleFor(model => model.Username).SetValidator(RegexValidator.Username);
            RuleFor(model => model.Password).SetValidator(RegexValidator.Password);
        }
    }
}
