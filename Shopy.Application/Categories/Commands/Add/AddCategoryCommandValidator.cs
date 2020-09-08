using FluentValidation;
using Shopy.Application.Validation;

namespace Shopy.Application.Categories.Commands.Add
{
    public class DeleteCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty()
                .WithValidationCode(ValidationCode.Empty);
        }
    }
}
