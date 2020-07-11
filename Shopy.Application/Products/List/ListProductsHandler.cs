using Microsoft.EntityFrameworkCore;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using Shopy.Application.Models;
using Shopy.Domain.Entitties;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.List
{
    public class ListProductsHandler : ShopyRequestHandler<ListProductsQuery, PagedList<ProductResponse>>
    {
        public ListProductsHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<PagedList<ProductResponse>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            var products = Context.Products
                   .Include(p => p.Brand)
                   .Include(p => p.Sizes)
                       .ThenInclude(ps => ps.Size)
                   .Include(p => p.Categories)
                       .ThenInclude(pc => pc.Category);

            var pagedProducts = await FilterProducts(products, request);

            return pagedProducts.ToPageList<ProductResponse>();
        }

        private async Task<PagedList<Product>> FilterProducts(IQueryable<Product> products, ListProductsQuery query)
        {
            //price
            if (query.MinPrice.HasValue)
            {
                products = products
                    .Where(p => p.Price >= query.MinPrice.Value);
            }

            if (query.MaxPrice.HasValue)
            {
                products = products
                    .Where(p => p.Price <= query.MaxPrice.Value);
            }

            //size
            if (query.Sizes != null && query.Sizes.Any())
            {
                products = products
                    .Where(p => Size.Parse(query.Sizes).Any(fs => p.Sizes.Any(ps => ps.Size.Code == fs.Code)));
            }

            //brand
            if (query.Brands != null && query.Brands.Any())
            {
                products = products
                    .Where(p => Brand.Parse(query.Brands).Any(b => p.Brand.Code == b.Code));
            }

            //category
            if (query.CategoryExternalId.HasValue)
            {
                products = products
                    .Where(p => p.Categories.Any(c => c.Category.ExternalId == query.CategoryExternalId));
            }

            var totalCount = await products.CountAsync();
            var pageIndex = 0;
            var pageSize = totalCount;

            //paging
            if (query.IsPagingEnabled)
            {
                pageIndex = query.PageIndex.Value;
                pageSize = query.PageSize.Value;
            }

            return new PagedList<Product>(
                products,
                pageIndex,
                pageSize,
                totalCount);
        }
    }
}