using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopy.Api.Common;
using Shopy.Common;

namespace Shopy.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes(ApiConstants.ApplicationJson)]
    [Produces(ApiConstants.ApplicationJson)]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected IMediator Mediator => ServiceLocator.GetService<IMediator>();
    }
}
