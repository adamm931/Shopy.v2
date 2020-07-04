﻿using System;
using System.Collections.Generic;

namespace Shopy.Application.Models
{
    public class ProductDetailsResponse
    {
        public Guid ExternalId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public BrandResponse Brand { get; set; }

        public IEnumerable<SizeResponse> Sizes { get; set; }

        public IEnumerable<ProductCategoryResponse> Categories { get; set; }

        public IEnumerable<RelatedProductResponse> RelatedProducts { get; set; }
    }
}