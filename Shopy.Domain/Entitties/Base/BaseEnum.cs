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

        public string DisplayName => this.GetResourceManager().GetString(Code) ?? Code;

        public static IEnumerable<TEnum> All =>
            typeof(TEnum)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<TEnum>();

        protected BaseEnum(string code)
        {
            Code = code;
        }

        protected BaseEnum()
        {
        }

        public static TEnum From(TEnum @enum)
        {
            return @enum.MemberwiseClone() as TEnum;
        }

        public static TEnum Parse(string code) =>
            All.SingleOrDefault(item => item.Code.Equals(code, StringComparison.OrdinalIgnoreCase))
            ?? throw new EnumEntityNotFoundException(typeof(TEnum).Name, code);

        public static IEnumerable<TEnum> Parse(IEnumerable<string> codes)
        {
            foreach (var code in codes)
            {
                yield return Parse(code);
            }
        }
    }
}
