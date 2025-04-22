using EduQuest.Application.UseCases.Disciplinas.GetAll;
using EduQuest.Application.UseCases.Disciplinas.GetById;
using EduQuest.Application.UseCases.Disciplinas.Register;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredDisciplinaJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterDisciplinaUseCase useCase,
            [FromBody] RequestRegisterDisciplinaJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseDisciplinaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
        [FromServices] IGetDisciplinaByIdUseCase useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseDisciplinaJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(
        [FromServices] IGetAllDisciplinaUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }
    }
}
