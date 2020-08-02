using System.Collections.Generic;

namespace Shopy.Common.Interfaces
{
    public interface IPagedList<T>
    {
        IEnumerable<T> Items { get; set; }

        int PageIndex { get; set; }

        int PageSize { get; set; }

        int PageCount { get; set; }

        long TotalCount { get; set; }

        bool HasNextPage => (PageIndex + 1) < PageCount;
    }
}
