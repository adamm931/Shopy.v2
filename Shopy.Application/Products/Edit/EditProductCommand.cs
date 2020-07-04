﻿using MediatR;
using System;
using System.Collections.Generic;

namespace Shopy.Application.Products.Edit
{
    public class EditProductCommand : IRequest<Unit>
    {
        public Guid ExternalId { get; set; }

        public decimal? Price { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public IEnumerable<string> Sizes { get; set; }
    }
}