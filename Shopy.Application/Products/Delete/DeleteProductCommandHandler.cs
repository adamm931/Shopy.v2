﻿using MediatR;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Commands
{
    public class DeleteProductCommandHandler : ShopyRequestHandler<DeleteProductCommand>
    {
        public DeleteProductCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await Context.Products.ByExternalIdAsync(request.ExternalId);

            Context.Products.Remove(product);

            await Context.Save();

            return Unit.Value;
        }
    }
}