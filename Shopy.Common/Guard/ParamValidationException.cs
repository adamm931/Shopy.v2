using System;

namespace Shopy.Common.Guard
{
    public class ParamValidationException : ArgumentException
    {
        public ParamValidationException(ParamValidationCodes codes, params object[] @params)
            : base(codes.FormatLocalizedValue(@params))
        {
        }
    }
}
