﻿using Shopy.Domain.Enums;

namespace Shopy.Domain.Entitties
{
    public class ProductSize
    {
        public Product Product { get; private set; }

        public Size Size { get; private set; }

        public ProductSize(Product product, Size size)
        {
            Product = product;
            Size = size;
        }

        private ProductSize()
        { }
    }
}
