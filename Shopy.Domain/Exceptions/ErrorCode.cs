namespace Shopy.Domain.Exceptions
{
    public enum ErrorCode
    {
        /// <summary>
        /// '{0}' with identifier '{1}' is not found
        /// </summary>
        EntityNotFound,

        /// <summary>
        /// Code '{0}' is not valid for enum entity '{1}'
        /// </summary>
        EnumEntityInvalidCode
    }
}
