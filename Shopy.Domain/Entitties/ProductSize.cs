using Shopy.Domain.Entitties.Base;

namespace Shopy.Domain.Entitties
{
    public class ProductSize : Entity
    {
        public Product Product { get; private set; }

        public int ProductId { get; private set; }

        public Size Size { get; private set; }

        public int SizeId { get; private set; }

        public ProductSize(Product product, Size sizeType)
        {
            Product = product;
            Size = sizeType;
        }

        private ProductSize()
        { }
    }
}
