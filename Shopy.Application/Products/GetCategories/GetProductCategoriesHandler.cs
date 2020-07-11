using Microsoft.EntityFrameworkCore;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using Shopy.Application.Products.Get;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.GetCategories
{
    public class GetProductCategoriesHandler : ShopyRequestHandler<GetProductCategoriesQuery, IEnumerable<ProductCategoryResponse>>
    {
        public GetProductCategoriesHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<ProductCategoryResponse>> Handle(GetProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var productByExternalId = await Context.Products
                .Include(product => product.Categories)
                    .ThenInclude(productCategory => productCategory.Category)
                .ByExternalIdAsync(request.ExternalId);

            var categories = productByExternalId.Categories
                .Select(productCategory => productCategory.Category)
                .ToList();

            return categories.MapTo<IEnumerable<ProductCategoryResponse>>();
        }
    }
}
