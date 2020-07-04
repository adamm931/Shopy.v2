using Microsoft.AspNetCore.Mvc;
using Shopy.Application.Brands.List;
using System.Threading.Tasks;

namespace Shopy.Api.Controllers
{
    public class BrandsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await Mediator.Send(new ListBrandsQuery()));
    }
}
