using Microsoft.AspNetCore.Mvc;
using Shopy.Application.Sizes.List;
using System.Threading.Tasks;

namespace Shopy.Api.Controllers
{
    public class SizesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await Mediator.Send(new ListSizesQuery()));
    }
}
