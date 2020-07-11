using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.RemoveFromCategory
{
    public class RemoveProductFromCategoryCommandHandler : ShopyRequestHandler<RemoveProductFromCategoryCommand>
    {
        public RemoveProductFromCategoryCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(RemoveProductFromCategoryCommand request, CancellationToken cancellationToken)
        {
            var product = await Context.Products
                .Include(product => product.Categories)
                    .ThenInclude(productCategories => productCategories.Category)
                .ByExternalIdAsync(request.ProductExternalId);

            var category = await Context.Categories
                .ByExternalIdAsync(request.CategoryExternalId);

            product.RemoveCategory(request.CategoryExternalId);

            await Context.Save();

            return Unit.Value;
        }
    }
}