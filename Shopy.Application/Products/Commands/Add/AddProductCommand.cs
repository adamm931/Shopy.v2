using Shopy.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace Shopy.Application.Products.Add
{
    public class AddProductCommand : ICommand<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string BrandCode { get; set; }

        public IEnumerable<string> SizeCodes { get; set; }
    }
}