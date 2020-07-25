using Shopy.Application.Interfaces;
using System;

namespace Shopy.Application.Products.AddToCategory
{
    public class AddProductToCategoryCommand : ICommand
    {
        public Guid ProductExternalId { get; set; }

        public Guid CategoryExternalId { get; set; }
    }
}