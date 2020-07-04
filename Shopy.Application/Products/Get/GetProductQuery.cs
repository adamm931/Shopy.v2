using MediatR;
using Shopy.Application.Models;
using System;

namespace Shopy.Application.Products.Get
{
    public class GetProductQuery : IRequest<ProductResponse>
    {
        public Guid ExternalId { get; set; }

        public GetProductQuery(Guid uid)
        {
            ExternalId = uid;
        }

        public GetProductQuery()
        {

        }
    }
}