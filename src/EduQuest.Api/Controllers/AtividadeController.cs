using EduQuest.Application.UseCases.Atividades.GetAllAvailableAtividadeByTurmaIdUseCase.cs;
using EduQuest.Application.UseCases.Atividades.GetAllAvailableByAlunoId;
using EduQuest.Application.UseCases.Atividades.GetAllAvailableByProfessorId;
using EduQuest.Application.UseCases.Atividades.GetAllByAlunoId;
using EduQuest.Application.UseCases.Atividades.GetAllByProfessorId;
using EduQuest.Application.UseCases.Atividades.GetAllByTurmaId;
using EduQuest.Application.UseCases.Atividades.GetById;
using EduQuest.Application.UseCases.Atividades.Register;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredAtividadeJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterAtividadeUseCase useCase,
            [FromBody] RequestRegisterAtividadeJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseAtividadeJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
        [FromServices] IGetAtividadeByIdUseCase useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("aluno/{alunoId}")]
        [ProducesResponseType(typeof(List<ResponseAtividadeJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByAlunoId(
        [FromServices] IGetAllAtividadeByAlunoIdUseCase useCase,
        [FromRoute] int alunoId)
        {
            var response = await useCase.Execute(alunoId);

            return Ok(response);
        }

        [HttpGet]
        [Route("professor/{professorId}")]
        [ProducesResponseType(typeof(List<ResponseAtividadeJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByProfessorId(
        [FromServices] IGetAllAtividadeByProfessorIdUseCase useCase,
        [FromRoute] int professorId)
        {
            var response = await useCase.Execute(professorId);

            return Ok(response);
        }

        [HttpGet]
        [Route("turma/{turmaId}")]
        [ProducesResponseType(typeof(List<ResponseAtividadeJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByTurmaId(
        [FromServices] IGetAllAtividadeByTurmaIdUseCase useCase,
        [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);

            return Ok(response);
        }

        [HttpGet]
        [Route("available/aluno/{alunoId}")]
        [ProducesResponseType(typeof(List<ResponseAtividadeJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAvailableByAlunoId(
        [FromServices] IGetAllAvailableAtividadeByAlunoIdUseCase useCase,
        [FromRoute] int alunoId)
        {
            var response = await useCase.Execute(alunoId);

            return Ok(response);
        }

        [HttpGet]
        [Route("available/professor/{professorId}")]
        [ProducesResponseType(typeof(List<ResponseAtividadeJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAvailableByProfessorId(
        [FromServices] IGetAllAvailableAtividadeByProfessorIdUseCase useCase,
        [FromRoute] int professorId)
        {
            var response = await useCase.Execute(professorId);

            return Ok(response);
        }

        [HttpGet]
        [Route("available/turma/{turmaId}")]
        [ProducesResponseType(typeof(List<ResponseAtividadeJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAvailableByTurmaId(
        [FromServices] IGetAllAvailableAtividadeByTurmaIdUseCase useCase,
        [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);

            return Ok(response);
        }
    }
}
