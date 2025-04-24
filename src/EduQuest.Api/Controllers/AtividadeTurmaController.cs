using EduQuest.Application.UseCases.AtividadeTurmas.Assign;
using EduQuest.Application.UseCases.AtividadeTurmas.Unassign;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeTurmaController : ControllerBase
    {
        [HttpPost]
        [Route("assign")]
        [ProducesResponseType(typeof(ResponseAssignedAtividadeToTurmaJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Assign(
            [FromServices] IAssignAtividadeToTurmaUseCase useCase,
            [FromBody] RequestAssignAtividadeToTurmaJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPost]
        [Route("unassign")]
        [ProducesResponseType(typeof(ResponseUnassignedAtividadeFromTurmaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Unassign(
            [FromServices] IUnassignAtividadeFromTurmaUseCase useCase,
            [FromRoute] int id)
        {
            await useCase.Execute(id);

            return Ok();
        }
    }
}
