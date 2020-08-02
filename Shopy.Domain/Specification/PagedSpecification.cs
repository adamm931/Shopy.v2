using Shopy.Domain.Entitties.Base;

namespace Shopy.Domain.Specification
{
    public class PagedSpecification<T> : Specification<T, IPagedSpecification<T>>, IPagedSpecification<T>
        where T : Entity
    {
        public int? PageIndex { get; }

        public int? PageSize { get; }

        public PagedSpecification(PagedSpecification<T> spec) : base(spec)
        {
            PageIndex = spec.PageIndex;
            PageSize = spec.PageSize;
        }

        public PagedSpecification(int? pageIndex, int? pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
