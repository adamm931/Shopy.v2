using Shopy.Common;
using Shopy.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Shopy.Domain.Entitties.Base
{
    public abstract class BaseEnum<TEnum> where TEnum : BaseEnum<TEnum>
    {
        public string Code { get; private set; }

        public string Label => this.GetResourceManager()?.GetString(Code) ?? Code;

        public static IEnumerable<TEnum> All { get; } = typeof(TEnum)
                .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<TEnum>();

        protected BaseEnum(string code)
        {
            Code = code;
        }

        protected BaseEnum()
        {
        }

        public static TEnum Parse(string code) =>
            All.FirstOrDefault(item => item.Code.Equals(code, StringComparison.OrdinalIgnoreCase))
            ?? throw new EnumEntityNotFoundException(typeof(TEnum).Name, code);

        public static bool TryParse(string code, out TEnum @enum)
        {
            @enum = All.FirstOrDefault(item => item.Code.Equals(code, StringComparison.OrdinalIgnoreCase));

            return @enum != null;
        }

        public static IEnumerable<TEnum> Parse(IEnumerable<string> codes)
        {
            foreach (var code in codes)
            {
                yield return Parse(code);
            }
        }
    }
}
