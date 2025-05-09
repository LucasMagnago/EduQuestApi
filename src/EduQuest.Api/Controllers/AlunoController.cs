using EduQuest.Application.UseCases.Alunos.GetAllByEscolaId;
using EduQuest.Application.UseCases.Alunos.GetAllByTurmaId;
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
        [Route("turma/{turmaId}")]
        [ProducesResponseType(typeof(List<ResponseAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByTurmaId(
        [FromServices] IGetAllAlunoByTurmaIdUseCase useCase,
        [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);

            return Ok(response);
        }

        [HttpGet]
        [Route("escola/{escolaId}")]
        [ProducesResponseType(typeof(List<ResponseAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByEscolaId(
        [FromServices] IGetAllAlunoByEscolaIdUseCase useCase,
        [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);

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
