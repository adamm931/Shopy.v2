using Shopy.Domain.Entitties.Base;
using System;
using System.Collections.Generic;

namespace Shopy.Domain.Entitties
{
    public class Brand : EnumEntity<Brand>
    {
        public static Brand Active = new Brand(nameof(Active));

        public static Brand Puma = new Brand(nameof(Puma));

        public static Brand Nike = new Brand(nameof(Nike));

        public static Brand Rebook = new Brand(nameof(Rebook));

        public static Brand Addidas = new Brand(nameof(Addidas));

        public List<Product> Products { get; set; }

        private Brand(string code) : base(code)
        {
            ExternalId = Guid.NewGuid();

            Products = new List<Product>();
        }

        private Brand()
        {
        }
    }
}