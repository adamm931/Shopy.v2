using MediatR;
using Shopy.Application.Models;
using System;

namespace Shopy.Application.Products.GetDetails
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsResponse>
    {
        public Guid ExternalId { get; set; }
    }
}