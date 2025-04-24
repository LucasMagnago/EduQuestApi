using EduQuest.Application.UseCases.Questoes.Register;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestaoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseQuestaoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterQuestaoUseCase useCase,
            [FromBody] RequestRegisterQuestaoJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        //[HttpGet]
        //[Route("{id}")]
        //[ProducesResponseType(typeof(ResponseAlternativaJson), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetById(
        //[FromServices] IGetAlternativaByIdUseCase useCase,
        //[FromRoute] int id)
        //{
        //    var response = await useCase.Execute(id);

        //    return Ok(response);
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Delete(
        //[FromServices] IDeleteAlternativaUseCase useCase,
        //[FromRoute] int id)
        //{
        //    await useCase.Execute(id);

        //    return NoContent();
        //}
    }
}
