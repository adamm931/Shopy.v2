using System.Text.Json;

namespace Shopy.Common.Extensions
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            IgnoreNullValues = true
        };

        public static string ToJson<TType>(this TType type)
            => JsonSerializer.Serialize(type, typeof(TType), jsonSerializerOptions);

        public static TType FromJson<TType>(this string json)
            => JsonSerializer.Deserialize<TType>(json, jsonSerializerOptions);
    }
}
