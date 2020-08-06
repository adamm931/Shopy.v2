using Shopy.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize, long totalCount)
            => new PagedList<T>(source, pageIndex, pageSize, totalCount);

        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageIndex, int pageSize, long totalCount)
            => new PagedList<T>(source, pageIndex, pageSize, totalCount);

        public static void Each<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
            => source.OrderBy(item => Guid.NewGuid());
    }
}
