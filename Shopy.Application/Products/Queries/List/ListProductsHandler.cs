using MediatR;
using Shopy.Application.Models;
using Shopy.Common.Paging;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using Shopy.Domain.Enums;
using Shopy.Domain.Specification;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.List
{
    public class ListProductsHandler : IRequestHandler<ListProductsQuery, IPagedList<ProductResponse>>
    {
        private readonly IRepository<Product> products;

        public ListProductsHandler(IRepository<Product> products)
        {
            this.products = products;
        }

        public async Task<IPagedList<ProductResponse>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            var specification = new PagedSpecification<Product>(request.PageIndex, request.PageSize)
                .AddInclude($"{nameof(Product.Brand)}")
                .AddInclude($"{nameof(Product.Sizes)}")
                .AddInclude($"{nameof(Product.Categories)}.{nameof(ProductCategory.Category)}");

            if (request.MinPrice.HasValue)
            {
                specification.And(p => p.Price >= request.MinPrice.Value);
            }

            if (request.MaxPrice.HasValue)
            {
                specification.And(p => p.Price <= request.MaxPrice.Value);
            }

            if (request.Sizes != null && request.Sizes.Any())
            {
                specification.And(p => Size.Parse(request.Sizes).Any(fs => p.Sizes.Any(ps => ps.Size.Code == fs.Code)));
            }

            if (request.Brands != null && request.Brands.Any())
            {
                specification.And(p => Brand.Parse(request.Brands).Any(b => p.Brand.Code == b.Code));
            }

            if (request.CategoryExternalId.HasValue)
            {

                specification.And(p => p.Categories.Any(c => c.Category.ExternalId == request.CategoryExternalId));
            }

            var pagedList = await products.PagedList(specification);

            return pagedList.ToPagedList<Product, ProductResponse>();
        }
    }
}