using Shopy.Domain.Entitties.Base;

namespace Shopy.Domain.Enums
{
    public class Size : BaseEnum<Size>
    {
        public static Size Xs => new Size("xs");

        public static Size S => new Size("s");

        public static Size M => new Size("m");

        public static Size L => new Size("l");

        public static Size Xl => new Size("xl");

        private Size(string code) : base(code)
        {
        }

        private Size()
        { }
    }
}