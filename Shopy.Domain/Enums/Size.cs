using Shopy.Domain.Entitties.Base;

namespace Shopy.Domain.Enums
{
    public class Size : BaseEnum<Size>
    {
        public static Size Xs => new Size("Xs");

        public static Size S => new Size("S");

        public static Size M => new Size("M");

        public static Size L => new Size("L");

        public static Size Xl => new Size("Xl");

        private Size(string code) : base(code) { }

        private Size() { }
    }
}