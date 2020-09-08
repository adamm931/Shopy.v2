using FluentValidation;
using Shopy.Application.Validation;

namespace Shopy.Application.Auth.CheckUsername
{
    public class CheckUsernameValidator : AbstractValidator<CheckUsernameCommand>
    {
        public CheckUsernameValidator()
        {
            RuleFor(model => model.Username)
                .NotEmpty()
                .WithValidationCode(ValidationCode.Empty);
        }
    }
}
