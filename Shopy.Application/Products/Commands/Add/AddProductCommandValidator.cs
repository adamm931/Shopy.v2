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
                .WithValidationMessageCode(ValidationCode.Empty);

            RuleFor(model => model.Sizes)
                .NotEmpty()
                .WithValidationMessageCode(ValidationCode.Empty);

            RuleFor(model => model.Name)
                .NotEmpty()
                .WithValidationMessageCode(ValidationCode.Empty);

            RuleFor(model => model.Description)
                .NotEmpty()
                .WithValidationMessageCode(ValidationCode.Empty);

            RuleFor(model => model.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0m)
                .WithValidationMessageCode(ValidationCode.Invalid);
        }
    }
}
