using FluentValidation;
using Shopy.Application.Products.Commands;
using Shopy.Application.Validation;

namespace Shopy.Application.Products.Delete
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(model => model.ExternalId)
                .NotEmpty()
                .WithValidationMessageCode(ValidationCode.Empty);
        }
    }
}
