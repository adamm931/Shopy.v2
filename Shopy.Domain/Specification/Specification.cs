using Shopy.Domain.Entitties.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shopy.Domain.Specification
{
    public class Specification<T, TSpec> : ISpecification<T, TSpec>
        where T : Entity
        where TSpec : ISpecification<T, TSpec>
    {
        internal List<string> includes = new List<string>();

        public Expression<Func<T, bool>> Criteria { get; internal set; } = (entity) => true;

        public ICollection<string> Includes => includes.AsReadOnly();

        public Specification()
        {
        }

        public Specification(TSpec spec)
        {
            includes = spec.Includes.ToList();
            Criteria = spec.Criteria;
        }

        public TSpec AddInclude(string include)
        {
            if (!includes.Contains(include))
            {
                includes.Add(include);
            }

            return (TSpec)Activator.CreateInstance(GetType(), this);
        }

        public TSpec And(Expression<Func<T, bool>> newCriteria)
        {
            var invoked = Expression.Invoke(newCriteria, Criteria.Parameters.Cast<Expression>());

            var andExpression = Expression.AndAlso(Criteria.Body, invoked);

            Criteria = Expression.Lambda<Func<T, bool>>(andExpression, Criteria.Parameters);

            return (TSpec)Activator.CreateInstance(GetType(), this);
        }
    }

    public class Specification<T> : Specification<T, ISpecification<T>>, ISpecification<T>
        where T : Entity
    {
        public Specification(Specification<T> specification) : base(specification)
        {
        }

        public Specification()
        {
        }

        public ISpecification<T> ByExternalId(Guid externalId) => And(entity => entity.ExternalId == externalId);
    }

}
