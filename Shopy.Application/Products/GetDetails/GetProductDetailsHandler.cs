using Microsoft.EntityFrameworkCore;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.GetDetails
{
    public class GetProductDetailsHandler : ShopyRequestHandler<GetProductDetailsQuery, ProductDetailsResponse>
    {
        public GetProductDetailsHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<ProductDetailsResponse> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product = await Context.Products
                    .Include(p => p.Categories)
                        .ThenInclude(pc => pc.Category)
                        .ThenInclude(p => p.Products)
                        .ThenInclude(ps => ps.Product)
                        .ThenInclude(ps => ps.Sizes)
                        .ThenInclude(ps => ps.Size)
                    .Include(p => p.Brand)
                    .Include(p => p.Sizes)
                        .ThenInclude(s => s.Size)
                    .ByExternalIdAsync(request.ExternalId);

            return product.MapTo<ProductDetailsResponse>();
        }
    }
}