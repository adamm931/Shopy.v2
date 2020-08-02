using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shopy.Api.Attributes;
using Shopy.Common;

namespace Shopy.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [BadRequest]
    [NotFound]
    [Unauthorized]
    [Produces("application/json")]
    public class BaseApiController : ControllerBase
    {
        protected IMediator Mediator => ServiceLocator.Provider.GetService<IMediator>();
    }
}
