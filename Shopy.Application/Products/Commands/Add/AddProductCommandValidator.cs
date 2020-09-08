using FluentValidation;
using Shopy.Application.Validation;

namespace Shopy.Application.Products.Add
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(model => model.Brand)
                .NotEmpty()
                .WithValidationCode(ValidationCode.Empty);

            RuleFor(model => model.Sizes)
                .NotEmpty()
                .WithValidationCode(ValidationCode.Empty);

            RuleFor(model => model.Name)
                .NotEmpty()
                .WithValidationCode(ValidationCode.Empty);

            RuleFor(model => model.Description)
                .NotEmpty()
                .WithValidationCode(ValidationCode.Empty);

            RuleFor(model => model.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0m)
                .WithValidationCode(ValidationCode.Invalid);
        }
    }
}
