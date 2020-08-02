using Shopy.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Common.Paging
{
    public class PagedList<T> : IPagedList<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public long TotalCount { get; set; }

        public bool HasNextPage => PageIndex + 1 < PageCount;

        public PagedList(IEnumerable<T> items, int pageIndex, int pageSize, long totalCount)
            : this(pageIndex, pageSize, totalCount)
        {
            Items = items;
        }

        public PagedList(IQueryable<T> items, int pageIndex, int pageSize, long totalCount)
            : this(pageIndex, pageSize, totalCount)
        {
            Items = items
                .Skip(pageIndex * pageSize)
                .Take((pageIndex + 1) * pageSize);
        }

        private PagedList(int pageIndex, int pageSize, long totalCount)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            PageCount = totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        internal PagedList()
        {
        }
    }
}
