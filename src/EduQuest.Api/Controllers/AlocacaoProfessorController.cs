using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.AddProfessor;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByProfessorId;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByTurmaId;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.RemoveProfessor;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlocacaoProfessorController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(ResponseAlocacaoProfessorJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProfessorToTurma(
            [FromServices] IAddProfessorToTurmaUseCase useCase,
            [FromBody] RequestAddProfessorToTurmaJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPost]
        [Route("remove")]
        //[ProducesResponseType(typeof(ResponseAlocacaoProfessorJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task RemoveProfessorFromTurma(
            [FromServices] IRemoveProfessorFromTurmaUseCase useCase,
            [FromBody] RequestRemoveProfessorFromTurmaJson request)
        {
            await useCase.Execute(request);
        }


        [HttpGet]
        [Route("turma/{id}")]
        [ProducesResponseType(typeof(List<ResponseProfessorDisciplinaJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByTurmaId(
        [FromServices] IGetAllAlocacaoByProfessorId useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("professor/{id}")]
        [ProducesResponseType(typeof(List<ResponseProfessorDisciplinaJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByProfessorId(
        [FromServices] IGetAllAlocacaoByTurmaId useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }
    }
}
