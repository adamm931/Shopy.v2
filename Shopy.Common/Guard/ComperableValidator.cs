using System;

namespace Shopy.Common.Guard
{
    public class ComperableValidator : IComperableValidator
    {
        public void GreaterThan<TNumber>(TNumber input, TNumber value, string name) where TNumber : IComparable
        {
            if (!(input.CompareTo(value) > 0))
            {
                throw new ParamValidationException(ParamValidationCodes.GreaterThan, name, value);
            }
        }

        public void GreaterThanOrEqual<TNumber>(TNumber input, TNumber value, string name) where TNumber : IComparable
        {
            if (!(input.CompareTo(value) >= 0))
            {
                throw new ParamValidationException(ParamValidationCodes.GreaterThanOrEqual, name, value);
            }
        }

        public void LowerThan<TNumber>(TNumber input, TNumber value, string name) where TNumber : IComparable
        {
            if (!(input.CompareTo(value) < 0))
            {
                throw new ParamValidationException(ParamValidationCodes.LowerThan, name, value);
            }
        }

        public void LowerThanOrEqual<TNumber>(TNumber input, TNumber value, string name) where TNumber : IComparable
        {
            if (!(input.CompareTo(value) <= 0))
            {
                throw new ParamValidationException(ParamValidationCodes.LowerThanOrEqual, name, value);
            }
        }
    }
}
