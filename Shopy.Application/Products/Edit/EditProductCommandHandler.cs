using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using Shopy.Domain.Entitties;
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
                       .Include(p => p.Sizes)
                           .ThenInclude(s => s.Size)
                       .Include(p => p.Brand)
                       .ByExternalIdAsync(request.ExternalId);

            product.UpdateName(request.Name);
            product.UpdateDescription(request.Description);
            product.UpdatePrice(request.Price);
            product.UpdateBrand(Brand.Parse(request.BrandCode));
            product.AddSizes(Size.Parse(request.SizeCodes));

            await Context.Save();

            return Unit.Value;
        }
    }
}