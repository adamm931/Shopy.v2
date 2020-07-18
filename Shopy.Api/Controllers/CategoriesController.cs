using Microsoft.AspNetCore.Mvc;
using Shopy.Application.Categories.Add;
using Shopy.Application.Categories.Delete;
using Shopy.Application.Categories.Edit;
using System.Threading.Tasks;

namespace Shopy.Api.Controllers
{
    public class CategoriesController : BaseApiController
    {
        [HttpGet]
        [Route("lookup")]
        public async Task<IActionResult> Lookup()
            => Ok(await Mediator.Send(new LookupCategoriesQuery()));

        [HttpGet]
        [Route("{externalId}/get")]
        public async Task<IActionResult> Get([FromRoute]GetCategoryQuery query)
            => Ok(await Mediator.Send(query));

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Post(AddCategoryCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Put(EditCategoryCommand command)
            => Ok(await Mediator.Send(command));

        [HttpDelete]
        [Route("{externalId}/delete")]
        public async Task<IActionResult> Delete([FromRoute]DeleteCategoryCommand query)
            => Ok(await Mediator.Send(query));
    }
}
