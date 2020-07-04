using FluentValidation;
using Shopy.Application.Categories.Add;
using Shopy.Application.Validation;

namespace Shopy.Application.Categories.Get
{
    public class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
    {
        public GetCategoryQueryValidator()
        {
            RuleFor(query => query.ExternalId)
                .NotEmpty()
                .WithValidationMessageCode(ValidationCode.Empty);
        }
    }
}
