using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Domain.Entitties.ValueObjects
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(T))
            {
                throw new Exception($"Can't compare value objects of different type");
            }

            if (!(obj is T compareTo))
            {
                return false;
            }

            return GetEqualityComponents().SequenceEqual(compareTo.GetEqualityComponents());
        }

        public override int GetHashCode()
         => GetEqualityComponents()
            .Aggregate(1, (current, obj) => current * 23 + (obj?.GetHashCode() ?? 0));

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b) => !(a == b);

        public override string ToString()
            => GetEqualityComponents().Aggregate(string.Empty, (current, next) => $"{current} {next}");
    }
}
