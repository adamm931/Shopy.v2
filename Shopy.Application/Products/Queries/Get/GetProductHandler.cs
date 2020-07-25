using MediatR;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Get
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, ProductResponse>
    {
        private readonly IRepository<Product> products;

        public GetProductHandler(IRepository<Product> products)
        {
            this.products = products;
        }

        public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var spec = new Specification<Product>()
                .AddInclude($"{nameof(Product.Sizes)}")
                .AddInclude($"{nameof(Product.Brand)}")
                .ByExternalId(request.ExternalId);

            var product = await products.Get(spec);

            return product.MapTo<ProductResponse>();
        }
    }
}