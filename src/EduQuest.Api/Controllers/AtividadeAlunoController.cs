using EduQuest.Application.UseCases.AtividadeAlunos.End;
using EduQuest.Application.UseCases.AtividadeAlunos.Start;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeAlunoController : ControllerBase
    {
        [HttpPost]
        [Route("start")]
        [ProducesResponseType(typeof(ResponseAtividadeAlunoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Start(
            [FromServices] IAlunoStartsAtividadeUseCase useCase,
            [FromBody] RequestAlunoStartsAtividadeJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPost]
        [Route("end")]
        [ProducesResponseType(typeof(ResponseAtividadeAlunoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> End(
            [FromServices] IAlunoEndsAtividadeUseCase useCase,
            [FromBody] RequestAlunoEndsAtividadeJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
