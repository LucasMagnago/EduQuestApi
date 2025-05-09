using EduQuest.Application.UseCases.Usuarios.GetAllByEscolaAndPerfilId;
using EduQuest.Application.UseCases.Usuarios.GetAllByEscolaId;
using EduQuest.Application.UseCases.Usuarios.GetById;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseUsuarioJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
        [FromServices] IGetUsuarioByIdUseCase useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("escola/{escolaId}")]
        [ProducesResponseType(typeof(List<ResponseUsuarioJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByEscolaId(
        [FromServices] IGetAllUsuarioByEscolaIdUseCase useCase,
        [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);

            return Ok(response);
        }

        [HttpGet]
        [Route("escola/{escolaId}/perfil/{perfilId}")]
        [ProducesResponseType(typeof(List<ResponseUsuarioJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByEscolaIdAndPerfilId(
        [FromServices] IGetAllUsuarioByEscolaIdAndPerfilIdUseCase useCase,
        [FromRoute] int escolaId,
        [FromRoute] int perfilId)
        {
            var response = await useCase.Execute(escolaId, perfilId);

            return Ok(response);
        }
    }
}
