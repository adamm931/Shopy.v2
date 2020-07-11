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
            var brand = Brand.Parse(request.BrandCode);
            var sizes = Size.Parse(request.SizeCodes);

            var product = new Product(
                request.Name,
                request.Description,
                request.Price,
                brand,
                sizes);

            Context.Products.Add(product);

            await Context.Save();

            return product.ExternalId;
        }
    }
}