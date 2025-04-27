using EduQuest.Application.UseCases.AtividadeQuestoes.GetAllByAtividadeId;
using EduQuest.Application.UseCases.AtividadeQuestoes.GetById;
using EduQuest.Application.UseCases.AtividadeQuestoes.Register;
using EduQuest.Application.UseCases.AtividadeQuestoes.Remove;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeQuestaoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseAtividadeQuestaoJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(
            [FromServices] IAddQuestaoToAtividadeUseCase useCase,
            [FromBody] RequestAddQuestaoToAtividadeJson request)
        {
            var response = await useCase.Execute(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = response.Id },
                response
            );
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(
            [FromServices] IRemoveQuestaoFromAtividadeUseCase useCase,
            [FromRoute] int id)
        {
            await useCase.Execute(id);

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseAtividadeQuestaoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
        [FromServices] IGetAtividadeQuestaoByIdUseCase useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("atividade/{atividadeId}")]
        [ProducesResponseType(typeof(List<ResponseQuestaoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllQuestaoByDisicplinaId(
        [FromServices] IGetAllQuestaoByAtividadeIdUseCase useCase,
        [FromRoute] int atividadeId)
        {
            var response = await useCase.Execute(atividadeId);

            return Ok(response);
        }
    }
}
