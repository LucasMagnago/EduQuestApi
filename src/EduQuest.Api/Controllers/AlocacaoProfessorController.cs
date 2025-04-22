using EduQuest.Application.UseCases.PeriodosLetivos.GetAll;
using EduQuest.Application.UseCases.PeriodosLetivos.GetById;
using EduQuest.Application.UseCases.PeriodosLetivos.Register;
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
        [ProducesResponseType(typeof(ResponseRegisteredPeriodoLetivoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterPeriodoLetivoUseCase useCase,
            [FromBody] RequestRegisterPeriodoLetivoJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponsePeriodoLetivoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
        [FromServices] IGetPeriodoLetivoByIdUseCase useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponsePeriodoLetivoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(
        [FromServices] IGetAllPeriodoLetivoUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }
    }
}
