using MediatR;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Commands.Add
{
    public class LookupCategoriesHandler : IRequestHandler<LookupCategoriesQuery, IEnumerable<LookupResponse>>
    {
        private readonly IRepository<Category> categories;

        public LookupCategoriesHandler(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public async Task<IEnumerable<LookupResponse>> Handle(LookupCategoriesQuery request, CancellationToken cancellationToken)
        {
            var list = await categories.List();

            return list.MapTo<IEnumerable<LookupResponse>>();
        }
    }
}