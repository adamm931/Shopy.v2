using Microsoft.EntityFrameworkCore;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using Shopy.Application.Mappings;
using Shopy.Application.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Add
{
    public class LookupCategoriesHandler : ShopyRequestHandler<LookupCategoriesQuery, IEnumerable<LookupResponse>>
    {
        public LookupCategoriesHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<LookupResponse>> Handle(LookupCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await Context.Categories.ToListAsync();

            return categories.MapTo<IEnumerable<LookupResponse>>();
        }
    }
}