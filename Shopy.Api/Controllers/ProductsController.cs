using Microsoft.AspNetCore.Mvc;
using Shopy.Application.Products.Add;
using Shopy.Application.Products.AddToCategory;
using Shopy.Application.Products.Commands;
using Shopy.Application.Products.Edit;
using Shopy.Application.Products.Get;
using Shopy.Application.Products.GetDetails;
using Shopy.Application.Products.List;
using Shopy.Application.Products.RemoveFromCategory;
using Shopy.Application.Products.UploadImage;
using System.Threading.Tasks;

namespace Shopy.Api.Controllers
{
    public class ProductsController : BaseApiController
    {
        [HttpGet]

        public async Task<IActionResult> List([FromQuery]ListProductsQuery query)
            => Ok(await Mediator.Send(query));

        [HttpGet]
        [Route("{externalId}")]
        public async Task<IActionResult> Get([FromRoute]GetProductQuery query)
            => Ok(await Mediator.Send(query));

        [HttpGet]
        [Route("{externalId}/details")]
        public async Task<IActionResult> Details([FromRoute]GetProductDetailsQuery query)
            => Ok(await Mediator.Send(query));

        [HttpGet]
        [Route("{externalId}/categories")]
        public async Task<IActionResult> Categories([FromRoute]GetProductCategoriesQuery query)
            => Ok(await Mediator.Send(query));

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Post(AddProductCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Put(EditProductCommand command)
            => Ok(await Mediator.Send(command));

        [HttpDelete]
        [Route("{externalId}/delete")]
        public async Task<IActionResult> Delete([FromRoute]DeleteProductCommand query)
            => Ok(await Mediator.Send(query));

        [HttpPost]
        [Route("add-to-category")]
        public async Task<IActionResult> AddToCategory(AddProductToCategoryCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPost]
        [Route("remove-from-category")]
        public async Task<IActionResult> RemoveFromCategory(RemoveProductFromCategoryCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPost]
        [Route("uploadImage")]
        public async Task<IActionResult> UploadImage(UploadProductImageCommand command)
            => Ok(await Mediator.Send(command));
    }
}
