using FluentValidation;
using Shopy.Common;

namespace Shopy.Application.Validation
{
    public static class FluentValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithValidationMessageCode<T, TProperty>(
                this IRuleBuilderOptions<T, TProperty> rule,
                ValidationCode code)
        {
            return rule.WithMessage(code.GetLocalizedValue());
        }
    }
}
