using EduQuest.Application.UseCases.Questoes.Delete;
using EduQuest.Application.UseCases.Questoes.GetAllByDisciplinaId;
using EduQuest.Application.UseCases.Questoes.GetAllByDisciplinaIdAndNivel;
using EduQuest.Application.UseCases.Questoes.GetAllByProfessorId;
using EduQuest.Application.UseCases.Questoes.GetById;
using EduQuest.Application.UseCases.Questoes.Register;
using EduQuest.Application.UseCases.Questoes.SetCorrectAlternativa;
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

            return CreatedAtAction(
                nameof(GetById),
                new { id = response.Id },
                response
            );
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(
            [FromServices] ISetQuestaoCorrectAlternativaUseCase useCase,
            [FromBody] RequestSetQuestaoCorrectAlternativaJson request,
            [FromRoute] int id)
        {
            await useCase.Execute(id, request);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteQuestaoUseCase useCase,
            [FromRoute] int id)
        {
            await useCase.Execute(id);

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseQuestaoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
        [FromServices] IGetQuestaoByIdUseCase useCase,
        [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("disciplina/{disciplinaId}")]
        [ProducesResponseType(typeof(List<ResponseQuestaoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByDisicplinaId(
        [FromServices] IGetAllQuestaoByDisciplinaIdUseCase useCase,
        [FromRoute] int disciplinaId)
        {
            var response = await useCase.Execute(disciplinaId);

            return Ok(response);
        }

        [HttpGet]
        [Route("disciplina/{disciplinaId}/nivel/{nivel}")]
        [ProducesResponseType(typeof(List<ResponseQuestaoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByDisicplinaIdAndNivel(
        [FromServices] IGetAllQuestaoByDisciplinaIdAndNivelUseCase useCase,
        [FromRoute] int disciplinaId,
        [FromRoute] int nivel)
        {
            var response = await useCase.Execute(disciplinaId, nivel);

            return Ok(response);
        }

        [HttpGet]
        [Route("professor/{professorId}")]
        [ProducesResponseType(typeof(List<ResponseQuestaoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByProfessoraId(
        [FromServices] IGetAllQuestaoByProfessorIdUseCase useCase,
        [FromRoute] int professorId)
        {
            var response = await useCase.Execute(professorId);

            return Ok(response);
        }
    }
}
