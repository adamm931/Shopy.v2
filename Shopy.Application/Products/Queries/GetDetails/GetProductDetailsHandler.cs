using MediatR;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.GetDetails
{
    public class GetProductDetailsHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsResponse>
    {
        private readonly IRepository<Product> products;

        public GetProductDetailsHandler(IRepository<Product> products)
        {
            this.products = products;
        }

        public async Task<ProductDetailsResponse> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var spec = new Specification<Product>()
                .AddInclude($"{nameof(Product.Categories)}" +
                    $".{nameof(ProductCategory.Category)}" +
                    $".{nameof(Category.Products)}" +
                    $".{nameof(ProductCategory.Product)}" +
                    $".{nameof(Product.Sizes)}")
                .AddInclude($"{nameof(Product.Brand)}")
                .AddInclude($"{nameof(Product.Sizes)}")
                .ByExternalId(request.ExternalId);

            var product = await products.Get(spec);

            return product.MapTo<ProductDetailsResponse>();
        }
    }
}