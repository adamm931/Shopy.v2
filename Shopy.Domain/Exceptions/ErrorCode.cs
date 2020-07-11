namespace Shopy.Domain.Exceptions
{
    public enum ErrorCode
    {
        /// <summary>
        /// '{0}' with identifier '{1}' is not found
        /// </summary>
        EntityNotFound,

        /// <summary>
        /// '{0}' with code '{1}' is not found
        /// </summary>
        EnumEntityNotFound
    }
}
