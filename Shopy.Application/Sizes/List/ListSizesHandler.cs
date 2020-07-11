using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using Shopy.Domain.Entitties;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Sizes.List
{
    public class ListSizesHandler : ShopyRequestHandler<ListSizesQuery, IEnumerable<SizeResponse>>
    {
        public ListSizesHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<SizeResponse>> Handle(ListSizesQuery request, CancellationToken cancellationToken)
            => await Task.FromResult(Size.All.MapTo<IEnumerable<SizeResponse>>());
    }
}