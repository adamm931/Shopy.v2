using Shopy.Application.Products.List;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Client.Extensions
{
    internal static class ApplicationModelsExtensions
    {
        public static string ToQueryString(this ListProductsQuery request)
        {
            var @params = new Dictionary<string, object>();

            if (request.Brands != null && request.Brands.Any())
            {
                @params.Add("brands", string.Join(",", request.Brands));
            }

            if (request.Sizes != null && request.Sizes.Any())
            {
                @params.Add("sizes", string.Join(",", request.Sizes));
            }

            if (request.MinPrice.HasValue)
            {
                @params.Add("minPrice", request.MinPrice.Value);
            }

            if (request.MaxPrice.HasValue)
            {
                @params.Add("maxPrice", request.MaxPrice.Value);
            }

            if (request.PageIndex.HasValue && request.PageSize.HasValue)
            {
                @params.Add("pageIndex", request.PageIndex.Value);
                @params.Add("pageSize", request.PageSize.Value);
            }

            if (request.CategoryExternalId.HasValue)
            {
                @params.Add("categoryExternalId", request.CategoryExternalId.Value);
            }

            if (!@params.Any())
            {
                return string.Empty;
            }

            var query = string.Join(
                    "&", @params.Select(kvp => $"{kvp.Key}={kvp.Value}"));

            return $"?{query}";
        }
    }
}
