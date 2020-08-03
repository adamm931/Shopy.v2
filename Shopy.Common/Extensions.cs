﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopy.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace Shopy.Common
{
    public static class Extensions
    {
        public static void Each<TItem>(this IEnumerable<TItem> items, Action<TItem> action)
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
        {
            return string.Format(value.GetLocalizedValue(), @params);
        }

        public static void AddOptions<TOptions>(this IServiceCollection services, IConfiguration configuration)
            where TOptions : class
        {
            var optionsName = typeof(TOptions).Name;

            services.Configure<TOptions>(configuration.GetSection(optionsName));
        }

        public static void AddInstallers(
            this IServiceCollection services,
            IConfiguration configuration,
            params Type[] sourceAssemlyTypes)
        {
            var installers = sourceAssemlyTypes
                .SelectMany(type => type.Assembly.GetTypes())
                .Where(type => typeof(IServiceInstaller).IsAssignableFrom(type))
                .Select(installerType => Activator.CreateInstance(installerType))
                .Cast<IServiceInstaller>();

            installers.Each(installer => installer.Install(services, configuration));
        }
    }

}
