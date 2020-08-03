using MediatR;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using Shopy.Domain.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Brands.List
{
    public class ListBrandsHandler : IRequestHandler<ListBrandsQuery, IEnumerable<BrandResponse>>
    {
        public async Task<IEnumerable<BrandResponse>> Handle(ListBrandsQuery request, CancellationToken cancellationToken)
            => await Task.FromResult(Brand.All.MapTo<IEnumerable<BrandResponse>>());
    }
}