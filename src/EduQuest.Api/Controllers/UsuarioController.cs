using EduQuest.Application.UseCases.Usuarios.Profile;
using EduQuest.Application.UseCases.Usuarios.Register;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUsuarioJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterUsuarioUseCase useCase,
            [FromBody] RequestRegisterUsuarioJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ResponseUsuarioProfileJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfile([FromServices] IGetUsuarioProfileUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }
    }
}
