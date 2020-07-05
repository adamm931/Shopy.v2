using Shopy.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Application.Models
{
    public class PagedList<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public long TotalCount { get; set; }

        public bool HasNextPage => (PageIndex + 1) < PageCount;

        public PagedList(IQueryable<T> items, int pageIndex, int pageSize, long totalCount)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            PageCount = totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)pageSize);

            TotalCount = totalCount;

            Items = items
                .Skip(pageIndex * pageSize)
                .Take((pageIndex + 1) * pageSize);
        }

        internal PagedList()
        {
        }

        public PagedList<TDst> ToPageList<TDst>()
        {
            return new PagedList<TDst>
            {
                PageIndex = PageIndex,
                PageCount = PageCount,
                PageSize = PageSize,
                TotalCount = TotalCount,
                Items = Items.MapTo<IEnumerable<TDst>>()
            };
        }
    }
}
