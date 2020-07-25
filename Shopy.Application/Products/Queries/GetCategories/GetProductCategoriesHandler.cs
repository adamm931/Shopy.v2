using MediatR;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using Shopy.Application.Products.Get;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.GetCategories
{
    public class GetProductCategoriesHandler : IRequestHandler<GetProductCategoriesQuery, IEnumerable<ProductCategoryResponse>>
    {
        private readonly IRepository<Product> products;

        public GetProductCategoriesHandler(IRepository<Product> products)
        {
            this.products = products;
        }

        public async Task<IEnumerable<ProductCategoryResponse>> Handle(GetProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var spec = new Specification<Product>()
                .AddInclude($"{nameof(Product.Categories)}.{nameof(ProductCategory.Category)}")
                .ByExternalId(request.ExternalId);

            var product = await products.Get(spec);

            var categories = product.Categories
                .Select(productCategory => productCategory.Category)
                .ToList();

            return categories.MapTo<IEnumerable<ProductCategoryResponse>>();
        }
    }
}
