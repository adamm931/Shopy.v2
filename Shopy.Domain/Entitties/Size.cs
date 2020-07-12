using Shopy.Domain.Entitties.Base;

namespace Shopy.Domain.Entitties
{
    public class Size : BaseEnum<Size>
    {
        public static Size XS => new Size(nameof(XS));

        public static Size S => new Size(nameof(S));

        public static Size M => new Size(nameof(M));

        public static Size L => new Size(nameof(L));

        public static Size XL => new Size(nameof(XL));

        private Size(string code) : base(code)
        {
        }

        private Size()
        { }
    }
}