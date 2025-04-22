namespace EduQuest.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class CursoController : ControllerBase
    //{
    //    [HttpPost]
    //    [ProducesResponseType(typeof(ResponseRegisteredCursoJson), StatusCodes.Status201Created)]
    //    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    //    public async Task<IActionResult> Register(
    //        [FromServices] IRegisterCursoUseCase useCase,
    //        [FromBody] RequestRegisterCursoJson request)
    //    {
    //        var response = await useCase.Execute(request);

    //        return Created(string.Empty, response);
    //    }

    //    [HttpGet]
    //    [Route("{id}")]
    //    [ProducesResponseType(typeof(ResponseCursoJson), StatusCodes.Status200OK)]
    //    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    //    public async Task<IActionResult> GetById(
    //    [FromServices] IGetCursoByIdUseCase useCase,
    //    [FromRoute] int id)
    //    {
    //        var response = await useCase.Execute(id);

    //        return Ok(response);
    //    }

    //    [HttpGet]
    //    [ProducesResponseType(typeof(List<ResponseCursoJson>), StatusCodes.Status200OK)]
    //    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    //    public async Task<IActionResult> GetAll(
    //    [FromServices] IGetAllCursoUseCase useCase)
    //    {
    //        var response = await useCase.Execute();

    //        return Ok(response);
    //    }
    //}
}
