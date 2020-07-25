﻿using MediatR;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Edit
{
    public class UpdateProductCommandHandler : IRequestHandler<EditProductCommand>
    {
        private readonly IRepository<Product> products;

        public UpdateProductCommandHandler(IRepository<Product> products)
        {
            this.products = products;
        }

        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var spec = new Specification<Product>()
                .AddInclude($"{nameof(Product.Sizes)}")
                .AddInclude($"{nameof(Product.Brand)}")
                .ByExternalId(request.ExternalId);

            var product = await products.Get(spec);

            product.UpdateName(request.Name);
            product.UpdateDescription(request.Description);
            product.UpdatePrice(request.Price);
            product.UpdateBrand(Brand.Parse(request.BrandCode));
            product.AddSizes(Size.Parse(request.SizeCodes));

            return Unit.Value;
        }
    }
}