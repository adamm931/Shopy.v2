using System;

namespace Shopy.Common.Guard
{
    public interface IComperableValidator
    {
        void GreaterThan<TNumber>(TNumber input, TNumber value, string name)
            where TNumber : IComparable;

        void GreaterThanOrEqual<TNumber>(TNumber input, TNumber value, string name)
            where TNumber : IComparable;

        void LowerThan<TNumber>(TNumber input, TNumber value, string name)
            where TNumber : IComparable;

        void LowerThanOrEqual<TNumber>(TNumber input, TNumber value, string name)
            where TNumber : IComparable;
    }
}
