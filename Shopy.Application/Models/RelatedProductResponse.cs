﻿using System;
using System.Collections.Generic;

namespace Shopy.Application.Models
{
    public class RelatedProductResponse
    {
        public Guid ExternalId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<SizeResponse> Sizes { get; set; }
    }
}
