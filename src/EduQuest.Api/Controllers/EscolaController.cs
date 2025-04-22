using EduQuest.Application.UseCases.Escolas.GetAll;
using EduQuest.Application.UseCases.Escolas.GetById;
using EduQuest.Application.UseCases.Escolas.Register;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredEscolaJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterEscolaUseCase useCase,
            [FromBody] RequestRegisterEscolaJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseEscolaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
        [FromServices] IGetEscolaByIdUseCase useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseEscolaJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(
        [FromServices] IGetAllEscolaUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }
    }
}
