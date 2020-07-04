using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Edit
{
    public class UpdateProductCommandHandler : ShopyRequestHandler<EditProductCommand>
    {
        public UpdateProductCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await Context.Products
                       .Include(p => p.ProductSizes)
                           .ThenInclude(s => s.Size)
                       .Include(p => p.Brand)
                       .ByExternalIdAsync(request.ExternalId);

            var brand = await Context.Brands.ByCodeAsync(request.Brand);
            var sizes = await Context.Sizes.ByCodesAsync(request.Sizes);

            product.Update(request.Name, request.Description, request.Price.Value, brand, sizes);

            await Context.Save();

            return Unit.Value;
        }
    }
}