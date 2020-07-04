using Microsoft.EntityFrameworkCore;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Get
{
    public class GetProductHandler : ShopyRequestHandler<GetProductQuery, ProductResponse>
    {
        public GetProductHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await Context.Products
                    .Include(p => p.ProductSizes)
                        .ThenInclude(ps => ps.Size)
                    .Include(p => p.Brand)
                    .ByExternalIdAsync(request.ExternalId);

            return product.MapTo<ProductResponse>();
        }
    }
}