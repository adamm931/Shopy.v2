using System;

namespace Shopy.Common
{
    public class Argument
    {
        public static void NotEmpty(string paramValue, string paramName)
        {
            if (string.IsNullOrEmpty(paramValue))
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void NotNegative(decimal paramValue, string paramName)
        {
            if (paramValue < decimal.Zero)
            {
                throw new ArgumentOutOfRangeException($"{paramName} can't have negative value");
            }
        }

        public static void NotNull<TParam>(TParam paramValue, string paramName) where TParam : class
        {
            if (paramValue == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }

}
