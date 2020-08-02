using MediatR;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using Shopy.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.AddToCategory
{
    public class AddProductToCategoryCommandHandler : IRequestHandler<AddProductToCategoryCommand>
    {
        private readonly IRepository<Product> products;
        private readonly IRepository<Category> categories;

        public AddProductToCategoryCommandHandler(
            IRepository<Product> products,
            IRepository<Category> categories)
        {
            this.products = products;
            this.categories = categories;
        }

        public async Task<Unit> Handle(AddProductToCategoryCommand request, CancellationToken cancellationToken)
        {
            var productSpec = new Specification<Product>()
                .ByExternalId(request.ProductExternalId)
                .AddInclude($"{nameof(Product.Categories)}.{nameof(ProductCategory.Category)}");

            var categorySpec = new Specification<Category>()
                .ByExternalId(request.CategoryExternalId);

            var product = await products.Get(productSpec);
            var category = await categories.Get(categorySpec);

            product.AddCategory(category);

            return Unit.Value;
        }
    }
}