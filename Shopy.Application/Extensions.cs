using Shopy.Application.Mappings;
using Shopy.Common.Interfaces;
using Shopy.Common.Paging;
using System.Collections.Generic;

namespace Shopy.Application
{
    public static class Extensions
    {
        public static IPagedList<TDst> ToPagedList<TSrc, TDst>(this IPagedList<TSrc> source)
        {
            var dstItems = source.Items.MapTo<IEnumerable<TDst>>();

            return new PagedList<TDst>(dstItems, source.PageIndex, source.PageSize, source.TotalCount);
        }
    }
}
