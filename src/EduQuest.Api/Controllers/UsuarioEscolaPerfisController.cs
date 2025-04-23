using EduQuest.Application.UseCases.UsuarioEscolaPerfis.Assign;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.Unassign;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioEscolaPerfisController : ControllerBase
    {
        [HttpPost]
        [Route("assign")]
        [ProducesResponseType(typeof(ResponseAssignedUsuarioJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AssignUserToSchoolWithRole(
            [FromServices] IAssingUserToSchoolWithRoleUseCase useCase,
            [FromBody] RequestAssignUsuarioJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPost]
        [Route("unassign")]
        [ProducesResponseType(typeof(ResponseUnassignedUsuarioJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UnassignUserToSchoolWithRole(
            [FromServices] IUnassignUserToSchoolWithRoleUseCase useCase,
            [FromBody] RequestUnassignUsuarioJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
