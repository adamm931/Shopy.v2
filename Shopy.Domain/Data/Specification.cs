using Shopy.Domain.Entitties.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shopy.Domain.Data
{
    public class Specification<TEntity> where TEntity : Entity
    {
        private readonly List<string> includes = new List<string>();

        public Expression<Func<TEntity, bool>> Criteria { get; private set; } = (entity) => true;

        public IReadOnlyCollection<string> Includes => includes.AsReadOnly();

        private Specification() { }

        public Specification<TEntity> AddInclude(string include)
        {
            if (!includes.Contains(include))
            {
                includes.Add(include);
            }

            return this;
        }

        public Specification<TEntity> And(Expression<Func<TEntity, bool>> newCriteria)
        {
            var invoked = Expression.Invoke(newCriteria, Criteria.Parameters.Cast<Expression>());

            var andExpression = Expression.AndAlso(Criteria.Body, invoked);

            Criteria = Expression.Lambda<Func<TEntity, bool>>(andExpression, Criteria.Parameters);

            return this;
        }

        public static Specification<TEntity> ByExternalId(Guid externalId)
            => new Specification<TEntity>().And(entity => entity.ExternalId == externalId);

        public static Specification<TEntity> Create() => new Specification<TEntity>();
    }
}
