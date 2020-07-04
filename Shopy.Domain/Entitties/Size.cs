using Shopy.Domain.Entitties.Base;
using System;
using System.Collections.Generic;

namespace Shopy.Domain.Entitties
{
    public class Size : EnumEntity<Size>
    {
        public static Size XS = new Size(nameof(XS));

        public static Size S = new Size(nameof(S));

        public static Size M = new Size(nameof(M));

        public static Size L = new Size(nameof(L));

        public static Size XL = new Size(nameof(XL));

        public ICollection<ProductSize> ProductSizes { get; private set; }

        private Size(string name) : base(name)
        {
            ExternalId = Guid.NewGuid();

            ProductSizes = new List<ProductSize>();
        }

        private Size()
        { }
    }
}