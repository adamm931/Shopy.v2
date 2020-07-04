using Shopy.Domain.Exceptions;

namespace Shopy.Domain.Domain.Exceptions
{
    public class EnumEntityInvalidCodeException : LocalizedException
    {
        public EnumEntityInvalidCodeException(string code, string enumEntityName)
            : base(ErrorCode.EnumEntityInvalidCode, code, enumEntityName)
        {
        }
    }
}
