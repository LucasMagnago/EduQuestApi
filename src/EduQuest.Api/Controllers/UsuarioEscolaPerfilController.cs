using EduQuest.Application.UseCases.UsuarioEscolaPerfis.Assign;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.GetAllByUsuarioId;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.GetAtivoByUsuarioId;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.SetAtivo;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.SetInativo;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.Unassign;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioEscolaPerfilController : ControllerBase
    {
        [HttpPost]
        [Route("assign")]
        [ProducesResponseType(typeof(ResponseAssignedUsuarioJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AssignUserToSchoolWithRole(
            [FromServices] IAssingUserToSchoolWithRoleUseCase useCase,
            [FromBody] RequestAssignUsuarioJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPost]
        [Route("unassign")]
        [ProducesResponseType(typeof(ResponseUnassignedUsuarioJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UnassignUserToSchoolWithRole(
            [FromServices] IUnassignUserToSchoolWithRoleUseCase useCase,
            [FromBody] RequestUnassignUsuarioJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPost]
        [Route("activate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Activate(
            [FromServices] ISetUsuarioEscolaPerfilAtivoUseCase useCase,
            [FromBody] RequestAssignUsuarioJson request)
        {
            await useCase.Execute(request);
            return Ok();
        }

        [HttpPost]
        [Route("disable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Disable(
            [FromServices] ISetUsuarioEscolaPerfilInativoUseCase useCase,
            [FromBody] RequestAssignUsuarioJson request)
        {
            await useCase.Execute(request);
            return Ok();
        }

        [HttpGet]
        [Route("usuario/{usuarioId}")]
        [ProducesResponseType(typeof(List<ResponseShortUsuarioEscolaPerfilJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByUsuarioId(
            [FromServices] IGetAllUsuarioEscolaPerfilByUsuarioIdUseCase useCase,
            [FromRoute] int usuarioId)
        {
            var result = await useCase.Execute(usuarioId);
            return Ok(result);
        }

        // TO DO: Get todos os usuários de uma escola

        // TO DO: Get todos os usuários de um perfilId para uma escolaId

        [HttpGet]
        [Route("usuario/{usuarioId}/ativo")]
        [ProducesResponseType(typeof(ResponseShortUsuarioEscolaPerfilJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAtivoByUsuarioId(
            [FromServices] IGetUsuarioEscolaPerfilAtivoByUsuarioIdUseCase useCase,
            [FromRoute] int usuarioId)
        {
            var result = await useCase.Execute(usuarioId);
            return Ok(result);
        }
    }
}
