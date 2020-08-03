using MediatR;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using Shopy.Domain.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Sizes.List
{
    public class ListSizesHandler : IRequestHandler<ListSizesQuery, IEnumerable<SizeResponse>>
    {
        public async Task<IEnumerable<SizeResponse>> Handle(ListSizesQuery request, CancellationToken cancellationToken)
            => await Task.FromResult(Size.All.MapTo<IEnumerable<SizeResponse>>());
    }
}