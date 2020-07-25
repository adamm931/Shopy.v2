﻿using MediatR;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Add
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IRepository<Product> products;

        public AddProductCommandHandler(IRepository<Product> products)
        {
            this.products = products;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                request.Name,
                request.Description,
                request.Price,
                Brand.Parse(request.BrandCode),
                Size.Parse(request.SizeCodes));

            await products.Add(product);

            return product.ExternalId;
        }
    }
}