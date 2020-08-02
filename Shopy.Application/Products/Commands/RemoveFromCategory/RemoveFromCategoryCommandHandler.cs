using MediatR;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using Shopy.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.RemoveFromCategory
{
    public class RemoveProductFromCategoryCommandHandler : IRequestHandler<RemoveProductFromCategoryCommand>
    {
        private readonly IRepository<Product> products;

        public RemoveProductFromCategoryCommandHandler(IRepository<Product> products)
        {
            this.products = products;
        }

        public async Task<Unit> Handle(RemoveProductFromCategoryCommand request, CancellationToken cancellationToken)
        {
            var productSpec = new Specification<Product>()
                .ByExternalId(request.ProductExternalId)
                .AddInclude($"{nameof(Product.Categories)}.{nameof(ProductCategory.Category)}");

            var product = await products.Get(productSpec);

            product.RemoveCategory(request.CategoryExternalId);

            return Unit.Value;
        }
    }
}