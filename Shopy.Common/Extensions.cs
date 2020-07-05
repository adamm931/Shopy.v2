using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace Shopy.Common
{
    public static class Extensions
    {
        public static void RemoveAll<TItem>(this ICollection<TItem> items, Func<TItem, bool> filter)
        {
            var listItems = items.ToList();

            foreach (var item in listItems.Where(filter))
            {
                items.Remove(item);
            }
        }

        public static void ForEach<TItem>(this IEnumerable<TItem> items, Action<TItem> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        public static IEnumerable<TItem> Randomize<TItem>(this IEnumerable<TItem> items)
        {
            return items.OrderBy(item => Guid.NewGuid());
        }

        public static string GetLocalizedValue<TEnum>(this TEnum value) where TEnum : Enum
        {
            var enumType = value.GetType();

            var resourceManager = new ResourceManager(enumType.FullName, enumType.Assembly);
            var key = value.ToString();

            return resourceManager.GetString(key) ?? key;
        }

        public static string FormatLocalizedValue<TEnum>(this TEnum value, params object[] @params) where TEnum : Enum
        {
            return string.Format(value.GetLocalizedValue(), @params);
        }

        public static void AddOptions<TOptions>(this IServiceCollection services, IConfiguration configuration)
            where TOptions : class
        {
            var optionsName = typeof(TOptions).Name;

            services.Configure<TOptions>(configuration.GetSection(optionsName));
        }
    }

}
