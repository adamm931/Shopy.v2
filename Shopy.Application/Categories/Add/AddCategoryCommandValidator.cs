using FluentValidation;
using Shopy.Application.Validation;

namespace Shopy.Application.Categories.Add
{
    public class DeleteCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty()
                .WithValidationMessageCode(ValidationCode.Empty);
        }
    }
}
