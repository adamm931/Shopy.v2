using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Shopy.Common.Guard
{
    public class ParamValidator : ComperableValidator, IParamValidator
    {
        public void NotEmpty<T>(T input, string name)
        {
            if (EqualityComparer<T>.Default.Equals(input, default))
            {
                throw new ParamValidationException(ParamValidationCodes.NotEmpty, name);
            }
        }

        public void NotNull<T>(T input, string name)
        {
            if (input == null)
            {
                throw new ParamValidationException(ParamValidationCodes.NotNull, name);
            }
        }

        public void NotNullOrEmpty(string input, string name)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ParamValidationException(ParamValidationCodes.NotNullOrEmpty, name);
            }
        }

        public void RegexMatch(string input, string name, string regex)
        {
            if (!Regex.IsMatch(input, regex))
            {
                throw new ParamValidationException(ParamValidationCodes.RegexMatch, name, regex);
            }
        }
    }
}
