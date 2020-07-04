using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using Shopy.Domain.Entitties;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Add
{
    public class AddProductCommandHandler : ShopyRequestHandler<AddProductCommand, Guid>
    {
        public AddProductCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                request.Name,
                request.Description,
                request.Price.Value);

            var brand = await Context.Brands.ByCodeAsync(request.Brand);

            product.SetBrand(brand);

            foreach (var size in await Context.Sizes.ByCodesAsync(request.Sizes))
            {
                product.AddSize(size);
            }

            Context.Products.Add(product);

            await Context.Save();

            return product.ExternalId;
        }
    }
}