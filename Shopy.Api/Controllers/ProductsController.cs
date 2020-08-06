using Microsoft.AspNetCore.Mvc;
using Shopy.Api.Attributes;
using Shopy.Application.Models;
using Shopy.Application.Products.Add;
using Shopy.Application.Products.AddToCategory;
using Shopy.Application.Products.Commands;
using Shopy.Application.Products.Edit;
using Shopy.Application.Products.Get;
using Shopy.Application.Products.GetDetails;
using Shopy.Application.Products.List;
using Shopy.Application.Products.RemoveFromCategory;
using Shopy.Application.Products.UploadImage;
using Shopy.Common.Paging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Api.Controllers
{
    public class ProductsController : BaseApiController
    {
        [HttpGet]
        [SwaggerResponse(typeof(IPagedList<ProductResponse>))]
        public async Task<IActionResult> List([FromQuery]ListProductsQuery query)
            => Ok(await Mediator.Send(query));

        [HttpGet]
        [Route("{externalId}/get")]
        [SwaggerResponse(typeof(ProductResponse))]
        public async Task<IActionResult> Get([FromRoute]GetProductQuery query)
            => Ok(await Mediator.Send(query));

        [HttpGet]
        [Route("{externalId}/details")]
        [SwaggerResponse(typeof(ProductDetailsResponse))]
        public async Task<IActionResult> Details([FromRoute]GetProductDetailsQuery query)
            => Ok(await Mediator.Send(query));

        [HttpGet]
        [Route("{externalId}/categories")]
        [SwaggerResponse(typeof(IEnumerable<ProductCategoryResponse>))]
        public async Task<IActionResult> Categories([FromRoute]GetProductCategoriesQuery query)
            => Ok(await Mediator.Send(query));

        [HttpPost]
        [Route("add")]
        [SwaggerResponse(typeof(Guid))]
        public async Task<IActionResult> Post(AddProductCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPut]
        [Route("edit")]
        [SwaggerResponse]
        public async Task<IActionResult> Put(EditProductCommand command)
            => Ok(await Mediator.Send(command));

        [HttpDelete]
        [Route("{externalId}/delete")]
        [SwaggerResponse]
        public async Task<IActionResult> Delete([FromRoute]DeleteProductCommand query)
            => Ok(await Mediator.Send(query));

        [HttpPost]
        [Route("add-to-category")]
        [SwaggerResponse]
        public async Task<IActionResult> AddToCategory(AddProductToCategoryCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPost]
        [Route("remove-from-category")]
        [SwaggerResponse]
        public async Task<IActionResult> RemoveFromCategory(RemoveProductFromCategoryCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPost]
        [Route("uploadImage")]
        [SwaggerResponse]
        public async Task<IActionResult> UploadImage(UploadProductImageCommand command)
            => Ok(await Mediator.Send(command));
    }
}
