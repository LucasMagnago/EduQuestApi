using EduQuest.Application.UseCases.Turmas.AddAluno;
using EduQuest.Application.UseCases.Turmas.GetAll;
using EduQuest.Application.UseCases.Turmas.GetById;
using EduQuest.Application.UseCases.Turmas.Register;
using EduQuest.Application.UseCases.Turmas.RemoveAluno;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredTurmaJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterTurmaUseCase useCase,
            [FromBody] RequestRegisterTurmaJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseTurmaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
        [FromServices] IGetTurmaByIdUseCase useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseTurmaJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(
        [FromServices] IGetAllTurmaUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpPost]
        [Route("add-aluno")]
        [ProducesResponseType(typeof(List<ResponseAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddAlunoToTurma(
        [FromServices] IAddAlunoToTurmaUseCase useCase,
        [FromBody] RequestAddAlunoToTurmaJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("remove-aluno")]
        [ProducesResponseType(typeof(List<ResponseAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveAlunoFromTurma(
        [FromServices] IRemoveAlunoFromTurmaUseCase useCase,
        [FromBody] RequestRemoveAlunoFromTurmaJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
