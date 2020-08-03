using Microsoft.AspNetCore.Mvc;
using Shopy.Api.Attributes;
using Shopy.Application.Brands.List;
using Shopy.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Api.Controllers
{
    public class BrandsController : BaseApiController
    {
        [HttpGet]
        [SwaggerResponse(typeof(IEnumerable<BrandResponse>))]
        public async Task<IActionResult> Get()
            => Ok(await Mediator.Send(new ListBrandsQuery()));
    }
}
