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
                .WithValidationCode(ValidationCode.Empty);

            RuleFor(model => model.ProductExternalId)
                .NotEmpty()
                .WithValidationCode(ValidationCode.Empty);
        }
    }
}
