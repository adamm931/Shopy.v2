using Shopy.Application.Interfaces;
using System;

namespace Shopy.Application.Products.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public Guid ExternalId { get; set; }
    }
}