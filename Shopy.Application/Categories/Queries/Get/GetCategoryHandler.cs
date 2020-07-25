using MediatR;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Queries.Get
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, CategoryReponse>
    {
        private readonly IRepository<Category> categories;

        public GetCategoryHandler(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public async Task<CategoryReponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await categories.Get(request.ExternalId);

            return category.MapTo<CategoryReponse>();
        }
    }
}