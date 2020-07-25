using FluentValidation;
using Shopy.Application.Validation;

namespace Shopy.Application.Categories.Edit
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(command => command.ExternalId)
                .NotEmpty()
                .WithValidationMessageCode(ValidationCode.Empty);

            RuleFor(command => command.Name)
                .NotEmpty()
                .WithValidationMessageCode(ValidationCode.Empty);
        }
    }
}
