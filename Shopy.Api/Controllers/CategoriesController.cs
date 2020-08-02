using Microsoft.AspNetCore.Mvc;
using Shopy.Api.Attributes;
using Shopy.Application.Categories.Commands.Add;
using Shopy.Application.Categories.Delete;
using Shopy.Application.Categories.Edit;
using Shopy.Application.Categories.Queries.Get;
using Shopy.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Api.Controllers
{
    public class CategoriesController : BaseApiController
    {
        [HttpGet]
        [Route("lookup")]
        [Ok(typeof(IEnumerable<LookupResponse>))]
        public async Task<IActionResult> Lookup()
            => Ok(await Mediator.Send(new LookupCategoriesQuery()));

        [HttpGet]
        [Route("{externalId}/get")]
        [Ok(typeof(CategoryReponse))]
        public async Task<IActionResult> Get([FromRoute]GetCategoryQuery query)
            => Ok(await Mediator.Send(query));

        [HttpPost]
        [Route("add")]
        [Ok(typeof(Guid))]
        public async Task<IActionResult> Post(AddCategoryCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPut]
        [Route("edit")]
        [Ok]
        public async Task<IActionResult> Put(EditCategoryCommand command)
            => Ok(await Mediator.Send(command));

        [HttpDelete]
        [Route("{externalId}/delete")]
        [Ok]
        public async Task<IActionResult> Delete([FromRoute]DeleteCategoryCommand query)
            => Ok(await Mediator.Send(query));
    }
}
