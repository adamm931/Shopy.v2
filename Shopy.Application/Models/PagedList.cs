using Shopy.Application.Mappings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Application.Models
{
    public class PagedList<T> : IEnumerable<T>
    {
        internal IEnumerable<T> Items { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public long TotalCount { get; set; }

        public bool HasNextPage => PageNumber < PageCount;

        public PagedList(IQueryable<T> items, int pageNumber, int pageSize, long totalCount)
        {
            // TODO: validate params

            PageNumber = pageNumber;
            PageSize = pageSize;
            PageCount = totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)pageSize);

            TotalCount = totalCount;

            Items = items
                .Skip(pageNumber * pageSize)
                .Take((pageNumber + 1) * pageSize);
        }

        internal PagedList()
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public PagedList<TDst> ToPageList<TDst>()
        {
            return new PagedList<TDst>
            {
                PageNumber = PageNumber,
                PageCount = PageCount,
                PageSize = PageSize,
                TotalCount = TotalCount,
                Items = Items.MapTo<IEnumerable<TDst>>()
            };
        }
    }
}
