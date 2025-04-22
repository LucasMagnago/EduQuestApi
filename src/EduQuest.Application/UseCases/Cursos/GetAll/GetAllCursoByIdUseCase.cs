namespace EduQuest.Application.UseCases.Cursos.GetAll
{
    //public class GetAllCursoUseCase : IGetAllCursoUseCase
    //{
    //    private readonly ICursoRepository _cursoRepository;
    //    private readonly IMapper _mapper;

    //    public GetAllCursoUseCase(ICursoRepository cursoRepository,
    //        IMapper mapper)
    //    {
    //        _cursoRepository = cursoRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task<List<ResponseCursoJson>> Execute()
    //    {
    //        var result = await _cursoRepository.GetAllAsync();

    //        if (result is null)
    //            throw new NotFoundException("Cursos não encontrados");

    //        return _mapper.Map<List<ResponseCursoJson>>(result);
    //    }
    //}
}
