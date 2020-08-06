using Shopy.Application.Mappings;
using Shopy.Common.Extensions;
using Shopy.Common.Paging;
using System.Collections.Generic;

namespace Shopy.Application
{
    public static class Extensions
    {
        public static IPagedList<TDst> ToPagedList<TSrc, TDst>(this IPagedList<TSrc> source)
             => source.Items
                .MapTo<IEnumerable<TDst>>()
                .ToPagedList(source.PageIndex, source.PageSize, source.TotalCount);
    }
}
