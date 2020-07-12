using Shopy.Domain.Entitties.Base;

namespace Shopy.Domain.Entitties
{
    public class Brand : BaseEnum<Brand>
    {
        public static Brand Active => new Brand(nameof(Active));

        public static Brand Puma => new Brand(nameof(Puma));

        public static Brand Nike => new Brand(nameof(Nike));

        public static Brand Rebook => new Brand(nameof(Rebook));

        public static Brand Addidas => new Brand(nameof(Addidas));

        private Brand(string code) : base(code)
        {
        }

        private Brand()
        {
        }
    }
}