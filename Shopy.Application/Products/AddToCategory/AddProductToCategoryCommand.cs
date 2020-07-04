using MediatR;
using System;

namespace Shopy.Application.Products.AddToCategory
{
    public class AddProductToCategoryCommand : IRequest<Unit>
    {
        public Guid ProductExternalId { get; set; }

        public Guid CategoryExternalId { get; set; }
    }
}