using MediatR;
using Shopy.Application.Models;
using System;
using System.Collections.Generic;

namespace Shopy.Application.Products.Get
{
    public class GetProductCategoriesQuery : IRequest<IEnumerable<ProductCategoryResponse>>
    {
        public Guid ExternalId { get; set; }
    }
}