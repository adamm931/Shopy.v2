using FluentValidation;

namespace Shopy.Application.Validation
{
    public abstract class RegexValidator : AbstractValidator<string>
    {
        public static RegexValidator Username = new UsernameValidator();

        public static RegexValidator Password = new PasswordValidator();

        public static RegexValidator Email = new EmailValidator();

        protected RegexValidator(string regex)
        {
            RuleFor(model => model).Matches(regex).WithValidationCode(ValidationCode.DoesntMeetRequirments);
        }
    }

    public class UsernameValidator : RegexValidator
    {
        public UsernameValidator() : base(Domain.Entitties.ValueObjects.Username.Regex)
        {
        }
    }

    public class PasswordValidator : RegexValidator
    {
        public PasswordValidator() : base(Domain.Entitties.ValueObjects.Password.Regex)
        {
        }
    }

    public class EmailValidator : RegexValidator
    {
        public EmailValidator() : base(Domain.Entitties.ValueObjects.Email.Regex)
        {
        }
    }
}
