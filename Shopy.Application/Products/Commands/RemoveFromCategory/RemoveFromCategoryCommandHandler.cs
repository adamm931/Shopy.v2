using MediatR;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
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
                .AddInclude($"{nameof(Product.Categories)}.{nameof(ProductCategory.Category)}")
                .ByExternalId(request.ProductExternalId);

            var product = await products.Get(productSpec);

            product.RemoveCategory(request.CategoryExternalId);

            return Unit.Value;
        }
    }
}