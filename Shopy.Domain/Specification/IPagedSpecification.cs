using Shopy.Domain.Entitties.Base;

namespace Shopy.Domain.Specification
{
    public interface IPagedSpecification<T> : ISpecification<T, IPagedSpecification<T>>
        where T : Entity
    {
        int? PageSize { get; }

        int? PageIndex { get; }
    }
}

