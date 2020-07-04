using MediatR;
using System;

namespace Shopy.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public Guid ExternalId { get; set; }

        public DeleteProductCommand(Guid id)
        {
            ExternalId = id;
        }
    }
}