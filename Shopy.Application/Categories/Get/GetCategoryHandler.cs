using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Add
{
    public class GetCategoryHandler : ShopyRequestHandler<GetCategoryQuery, CategoryReponse>
    {
        public GetCategoryHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<CategoryReponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await Context.Categories.ByExternalIdAsync(request.ExternalId);

            return category.MapTo<CategoryReponse>();
        }
    }
}