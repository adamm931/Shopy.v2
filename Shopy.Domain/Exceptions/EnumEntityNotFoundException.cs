namespace Shopy.Domain.Exceptions
{
    public class EnumEntityNotFoundException : LocalizedException
    {
        public EnumEntityNotFoundException(string nameOfEnum, string code) : base(ErrorCode.EnumEntityNotFound, nameOfEnum, code)
        {
        }
    }
}
