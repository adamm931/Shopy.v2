using FluentValidation;
using Shopy.Application.Validation;

namespace Shopy.Application.Products.AddToCategory
{
    public class AddProductToCategoryCommandValidator : AbstractValidator<AddProductToCategoryCommand>
    {
        public AddProductToCategoryCommandValidator()
        {
            RuleFor(model => model.CategoryExternalId)
                .NotEmpty()
                .WithValidationMessageCode(ValidationCode.Empty);

            RuleFor(model => model.ProductExternalId)
                .NotEmpty()
                .WithValidationMessageCode(ValidationCode.Empty);
        }
    }
}
