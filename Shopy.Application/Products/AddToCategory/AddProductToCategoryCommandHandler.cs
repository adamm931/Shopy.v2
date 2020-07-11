using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.AddToCategory
{
    public class AddProductToCategoryCommandHandler : ShopyRequestHandler<AddProductToCategoryCommand>
    {
        public AddProductToCategoryCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(AddProductToCategoryCommand request, CancellationToken cancellationToken)
        {
            var product = await Context.Products
                .Include(product => product.Categories)
                    .ThenInclude(productCategory => productCategory.Category)
                .ByExternalIdAsync(request.ProductExternalId);

            var category = await Context.Categories
                .ByExternalIdAsync(request.CategoryExternalId);

            product.AddCategory(category);

            await Context.Save();

            return Unit.Value;
        }
    }
}