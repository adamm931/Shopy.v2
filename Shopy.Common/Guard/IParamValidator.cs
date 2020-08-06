namespace Shopy.Common.Guard
{
    public interface IParamValidator : IComperableValidator
    {
        void NotNullOrEmpty(string input, string name);

        void NotNull<T>(T input, string name);

        void NotEmpty<T>(T input, string name);

        void RegexMatch(string input, string name, string regex);
    }
}
