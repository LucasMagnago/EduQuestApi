namespace EduQuest.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class MatriculaController : ControllerBase
    //{
    //    [HttpPost]
    //    [ProducesResponseType(typeof(ResponseRegisteredMatriculaJson), StatusCodes.Status201Created)]
    //    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    //    public async Task<IActionResult> Matricular(
    //        [FromServices] IRegisterMatriculaUseCase useCase,
    //        [FromBody] RequestRegisterMatriculaJson request)
    //    {
    //        var response = await useCase.Execute(request);

    //        return Created(string.Empty, response);
    //    }

    //    [HttpPost("transferir/{matriculaId}")]
    //    [ProducesResponseType(typeof(ResponseRegisteredTransferenciaJson), StatusCodes.Status201Created)]
    //    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    //    public async Task<IActionResult> Transferir(
    //        [FromServices] IRegisterTransferenciaUseCase useCase,
    //        [FromRoute] int matriculaId)
    //    {
    //        var response = await useCase.Execute(matriculaId);

    //        return Created(string.Empty, response);
    //    }

    //    [HttpGet]
    //    [Route("all/{alunoId}")]
    //    [ProducesResponseType(typeof(List<ResponseMatriculaJson>), StatusCodes.Status200OK)]
    //    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    //    public async Task<IActionResult> GetAllByAlunoId(
    //    [FromServices] IGetAllMatriculaByAlunoId useCase,
    //    [FromRoute] int alunoId)
    //    {
    //        var response = await useCase.Execute(alunoId);

    //        return Ok(response);
    //    }

    //    [HttpGet]
    //    [Route("{id}")]
    //    [ProducesResponseType(typeof(ResponseMatriculaJson), StatusCodes.Status200OK)]
    //    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    //    public async Task<IActionResult> GetById(
    //    [FromServices] IGetMatriculaByIdUseCase useCase,
    //    [FromRoute] int id)
    //    {
    //        var response = await useCase.Execute(id);

    //        return Ok(response);
    //    }

    //    [HttpGet]
    //    [ProducesResponseType(typeof(List<ResponseTurmaJson>), StatusCodes.Status200OK)]
    //    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    //    public async Task<IActionResult> GetAll(
    //    [FromServices] IGetAllTurmaUseCase useCase)
    //    {
    //        var response = await useCase.Execute();

    //        return Ok(response);
    //    }
    //}
}
