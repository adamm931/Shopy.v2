using Shopy.Common.Guard;

namespace Shopy.Common
{
    public class Param
    {
        public static IParamValidator Ensure = new ParamValidator();
    }
}
