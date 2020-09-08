using FluentValidation;
using Shopy.Common;
using Shopy.Domain.Entitties.ValueObjects;

namespace Shopy.Application.Validation
{
    public static class FluentValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithValidationCode<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule, ValidationCode code)
            => rule.WithMessage(code.GetLocalizedValue());

        public static IRuleBuilderOptions<T, string> UsernameValidation<T, TProperty>(this IRuleBuilderOptions<T, string> rule)
            => rule.Matches(Username.Regex).WithValidationCode(ValidationCode.DoesntMeetRequirments);

        public static IRuleBuilderOptions<T, string> PasswordValidation<T, TProperty>(this IRuleBuilderOptions<T, string> rule)
            => rule.Matches(Password.Regex).WithValidationCode(ValidationCode.DoesntMeetRequirments);

        public static IRuleBuilderOptions<T, string> EmailValidation<T, TProperty>(this IRuleBuilderOptions<T, string> rule)
            => rule.Matches(Email.Regex).WithValidationCode(ValidationCode.DoesntMeetRequirments);
    }
}
