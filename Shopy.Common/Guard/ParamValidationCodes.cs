namespace Shopy.Common.Guard
{
    public enum ParamValidationCodes
    {
        /// <summary>
        /// {0} must be greater than {1}
        /// </summary>
        GreaterThan,

        /// <summary>
        /// {0} must be greater than or equal to {1}
        /// </summary>
        GreaterThanOrEqual,

        /// <summary>
        /// {0} must be lower than {1}
        /// </summary>
        LowerThan,

        /// <summary>
        /// {0} must be lower than or equal to {1}
        /// </summary>
        LowerThanOrEqual,

        /// <summary>
        /// {0} can't be null
        /// </summary>
        NotNull,

        /// <summary>
        /// {0} can't be null or empty
        /// </summary>
        NotNullOrEmpty,

        /// <summary>
        /// {0} can't be empty
        /// </summary>
        NotEmpty
    }
}
