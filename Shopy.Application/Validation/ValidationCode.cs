namespace Shopy.Application.Validation
{
    public enum ValidationCode
    {
        /// <summary>
        /// Can't be null or empty
        /// </summary>
        Empty,

        /// <summary>
        /// Has invalid value
        /// </summary>
        Invalid,

        /// <summary>
        /// Doesn't meet requirments
        /// </summary>
        DoesntMeetRequirments
    }
}
