using Shopy.Domain.Entitties.Base;

namespace Shopy.Domain.Enums
{
    public class Brand : BaseEnum<Brand>
    {
        public static Brand Active => new Brand("active");

        public static Brand Puma => new Brand("puma");

        public static Brand Nike => new Brand("nike");

        public static Brand Rebook => new Brand("rebook");

        public static Brand Addidas => new Brand("addiddas");

        private Brand(string code) : base(code)
        {
        }

        private Brand()
        {
        }
    }
}