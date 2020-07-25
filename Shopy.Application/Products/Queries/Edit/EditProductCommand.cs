using Shopy.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace Shopy.Application.Products.Edit
{
    public class EditProductCommand : ICommand
    {
        public Guid ExternalId { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string BrandCode { get; set; }

        public IEnumerable<string> SizeCodes { get; set; }
    }
}