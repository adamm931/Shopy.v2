using Shopy.Application.Interfaces;
using System;

namespace Shopy.Application.Products.RemoveFromCategory
{
    public class RemoveProductFromCategoryCommand : ICommand
    {
        public Guid ProductExternalId { get; set; }

        public Guid CategoryExternalId { get; set; }
    }
}