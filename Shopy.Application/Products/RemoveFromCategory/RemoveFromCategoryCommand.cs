using MediatR;
using System;

namespace Shopy.Application.Products.RemoveFromCategory
{
    public class RemoveProductFromCategoryCommand : IRequest<Unit>
    {
        public Guid ProductExternalId { get; set; }

        public Guid CategoryExternalId { get; set; }
    }
}