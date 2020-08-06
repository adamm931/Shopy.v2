using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopy.Api.Attributes;
using Shopy.Application.Auth.Login;
using Shopy.Application.Auth.Register;
using Shopy.Application.Auth.Token;
using Shopy.Application.Models;
using System.Threading.Tasks;

namespace Shopy.Api.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseApiController
    {
        [HttpPost]
        [Route("login")]
        [SwaggerResponse(typeof(LoginResponse))]
        public async Task<IActionResult> Login(LoginCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPost]
        [Route("token")]
        [SwaggerResponse(typeof(TokenResponse))]
        public async Task<IActionResult> Token(TokenCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPost]
        [Route("register")]
        [SwaggerResponse]
        public async Task<IActionResult> Register(RegisterCommand command)
            => Ok(await Mediator.Send(command));
    }
}