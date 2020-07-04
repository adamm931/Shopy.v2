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
                    .Include(p => p.ProductCategories)
                        .ThenInclude(pc => pc.Category)
                        .ThenInclude(p => p.ProductCategories)
                        .ThenInclude(ps => ps.Product)
                        .ThenInclude(ps => ps.ProductSizes)
                        .ThenInclude(ps => ps.Size)
                    .Include(p => p.Brand)
                    .Include(p => p.ProductSizes)
                        .ThenInclude(s => s.Size)
                    .ByExternalIdAsync(request.ExternalId);

            return product.MapTo<ProductDetailsResponse>();
        }
    }
}