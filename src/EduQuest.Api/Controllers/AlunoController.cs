using EduQuest.Application.UseCases.Alunos.GetById;
using EduQuest.Application.UseCases.Alunos.GetTurmaByAlunoId;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseAlunoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
        [FromServices] IGetAlunoById useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}/turma")]
        [ProducesResponseType(typeof(ResponseTurmaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTurmaByAlunoId(
        [FromServices] IGetTurmaByAlunoId useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }
    }
}
