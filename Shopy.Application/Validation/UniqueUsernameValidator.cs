using FluentValidation;
using Shopy.Application.Interfaces;

namespace Shopy.Application.Validation
{
    public class UniqueUsernameValidator : AbstractValidator<string>
    {
        public UniqueUsernameValidator(IAuthService authService)
        {
            RuleFor(model => model)
                .MustAsync(async (value, token) => await authService.CheckUsername(value))
                .WithMessage(value => $"Username {value} is not available");
        }
    }
}
