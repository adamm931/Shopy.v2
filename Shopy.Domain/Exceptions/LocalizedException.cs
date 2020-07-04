using Shopy.Common;
using System;

namespace Shopy.Domain.Exceptions
{
    public abstract class LocalizedException : Exception
    {
        protected LocalizedException(ErrorCode code, params object[] @params) : base(code.FormatLocalizedValue(@params))
        {
        }
    }
}
