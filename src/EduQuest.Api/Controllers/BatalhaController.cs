using EduQuest.Application.UseCases.Batalhas.AddAluno;
using EduQuest.Application.UseCases.Batalhas.End;
using EduQuest.Application.UseCases.Batalhas.GetById;
using EduQuest.Application.UseCases.Batalhas.Register;
using EduQuest.Application.UseCases.Batalhas.Start;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseBatalhaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
        [FromServices] IGetBatalhaByIdUseCase useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBatalhaJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterBatalhaUseCase useCase,
            [FromBody] RequestRegisterBatalhaJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("start/")]
        [ProducesResponseType(typeof(List<ResponseBatalhaJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Start(
        [FromServices] IStartBatalhaUseCase useCase,
        [FromBody] RequestStartBatalhaJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }


        [HttpPut]
        [Route("end/")]
        [ProducesResponseType(typeof(List<ResponseBatalhaJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> End(
        [FromServices] IEndBatalhaUseCase useCase,
        [FromBody] RequestEndBatalhaJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpPut]
        [Route("add-aluno/")]
        [ProducesResponseType(typeof(List<ResponseBatalhaJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddAluno(
        [FromServices] IAddAlunoToBatalhaUseCase useCase,
        [FromBody] RequestAddAlunoToBatalhaJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
