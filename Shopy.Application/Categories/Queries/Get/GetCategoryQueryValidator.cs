using FluentValidation;
using Shopy.Application.Validation;

namespace Shopy.Application.Categories.Queries.Get
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
