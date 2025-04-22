using EduQuest.Application.UseCases.Auth.Login;
using EduQuest.Application.UseCases.Auth.Register;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ResponseRegisteredUsuarioJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterUsuarioUseCase useCase,
            [FromBody] RequestRegisterUsuarioJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ResponseLoggedUsuarioJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseLoggedUsuarioJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(
            [FromServices] ILoginUsuarioUseCase useCase,
            [FromBody] RequestLoginUsuarioJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
