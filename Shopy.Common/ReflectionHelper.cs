using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Shopy.Common
{
    public class ReflectionHelper
    {
        public static IEnumerable<T> GetInstances<T>() where T : class
        {
            return typeof(T)
                .GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(field => (T)field.GetValue(null));
        }
    }
}
