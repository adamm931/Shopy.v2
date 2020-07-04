using Microsoft.EntityFrameworkCore;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Brands.List
{
    public class ListBrandsHandler : ShopyRequestHandler<ListBrandsQuery, IEnumerable<BrandResponse>>
    {
        public ListBrandsHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<BrandResponse>> Handle(ListBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await Context.Brands.ToListAsync();

            return brands.MapTo<IEnumerable<BrandResponse>>();
        }
    }
}