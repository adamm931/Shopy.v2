using FluentValidation;
using Shopy.Application.Validation;

namespace Shopy.Application.Products.Edit
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(model => model.ExternalId)
                .NotEmpty()
                .WithValidationCode(ValidationCode.Empty);
        }
    }
}
