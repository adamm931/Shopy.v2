using Microsoft.AspNetCore.Mvc;
using Shopy.Api.Attributes;
using Shopy.Application.Models;
using Shopy.Application.Sizes.List;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Api.Controllers
{
    public class SizesController : BaseApiController
    {
        [HttpGet]
        [SwaggerResponse(typeof(IEnumerable<SizeResponse>))]
        public async Task<IActionResult> Get()
            => Ok(await Mediator.Send(new ListSizesQuery()));
    }
}
