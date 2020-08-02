using Shopy.Domain.Entitties.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shopy.Domain.Specification
{
    public interface ISpecification<T, TSpec>
        where T : Entity
        where TSpec : ISpecification<T, TSpec>
    {
        Expression<Func<T, bool>> Criteria { get; }

        ICollection<string> Includes { get; }

        TSpec AddInclude(string include);

        TSpec And(Expression<Func<T, bool>> criteria);
    }

    public interface ISpecification<T> : ISpecification<T, ISpecification<T>>
        where T : Entity
    { }

}
