using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopy.Application.Identity.Login;
using Shopy.Application.Identity.Token;
using System.Threading.Tasks;

namespace Shopy.Api.Controllers
{
    [AllowAnonymous]
    public class IdentityController : BaseApiController
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Token(TokenCommand command)
            => Ok(await Mediator.Send(command));
    }
}