using EduQuest.Application.UseCases.AtividadeRespostas.Answer;
using EduQuest.Application.UseCases.AtividadeRespostas.GetAllByAlunoIdAndAtividadeId;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeRespostaController : ControllerBase
    {
        [HttpPost]
        [Route("answer")]
        [ProducesResponseType(typeof(ResponseAtividadeRespostaJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Answer(
            [FromServices] IAlunoAnswerQuestaoFromAtividadeUseCase useCase,
            [FromBody] RequestAlunoAnswerQuestaoFromAtividadeJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPost]
        [Route("atividade/{atividadeId}/aluno/{alunoId}")]
        [ProducesResponseType(typeof(ResponseUnassignedAtividadeFromTurmaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByAlunoIdAndAtividadeId(
            [FromServices] IGetAllAtividadeRespostaByAlunoIdAndAtividadeIdUseCase useCase,
            [FromRoute] int atividadeId,
            [FromRoute] int alunoId)
        {
            await useCase.Execute(alunoId, atividadeId);

            return Ok();
        }
    }
}
