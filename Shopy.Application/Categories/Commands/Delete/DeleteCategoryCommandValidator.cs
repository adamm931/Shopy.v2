using FluentValidation;
using Shopy.Application.Validation;

namespace Shopy.Application.Categories.Delete
{
    public class EditCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(command => command.ExternalId)
                .NotEmpty()
                .WithValidationCode(ValidationCode.Empty);
        }
    }
}
