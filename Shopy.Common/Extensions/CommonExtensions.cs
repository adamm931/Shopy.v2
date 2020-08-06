using System;
using System.Linq;
using System.Resources;

namespace Shopy.Common
{
    public static class CommonExtensions
    {
        public static string GetLocalizedValue<TEnum>(this TEnum value) where TEnum : Enum
        {
            var resourceManager = value.GetResourceManager();
            var key = value.ToString();

            return resourceManager.GetString(key) ?? key;
        }

        public static ResourceManager GetResourceManager<TType>(this TType type)
        {
            var typeInfo = type.GetType();

            var resources = typeInfo.Assembly.GetManifestResourceNames();

            return resources.Any(name => name.Contains(typeInfo.FullName))
                ? new ResourceManager(typeInfo.FullName, typeInfo.Assembly)
                : null;
        }

        public static string FormatLocalizedValue<TEnum>(this TEnum value, params object[] @params) where TEnum : Enum
            => string.Format(value.GetLocalizedValue(), @params);
    }
}
