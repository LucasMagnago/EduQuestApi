using EduQuest.Application.UseCases.BatalhaRespostas.Answer;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaRespostaController : ControllerBase
    {
        //[HttpGet]
        //[Route("{id}")]
        //[ProducesResponseType(typeof(ResponseBatalhaJson), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetById(
        //[FromServices] IGetBatalhaByIdUseCase useCase,
        //[FromRoute] int id)
        //{
        //    var response = await useCase.Execute(id);

        //    return Ok(response);
        //}

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBatalhaRespostaJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Answer(
            [FromServices] IAlunoAnswerQuestaoFromBatalhaUseCase useCase,
            [FromBody] RequestAlunoAnswerQuestaoFromBatalhaJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
