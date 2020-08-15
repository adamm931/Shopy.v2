using Shopy.Domain.Entitties.Base;

namespace Shopy.Domain.Enums
{
    public class Brand : BaseEnum<Brand>
    {
        public static Brand Active => new Brand("Active");

        public static Brand Puma => new Brand("Puma");

        public static Brand Nike => new Brand("Nike");

        public static Brand Rebook => new Brand("Rebook");

        public static Brand Addidas => new Brand("Addiddas");

        private Brand(string code) : base(code) { }

        private Brand() { }
    }
}