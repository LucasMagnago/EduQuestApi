namespace EduQuest.Application.UseCases.Cursos.GetById
{
    //public class GetCursoByIdUseCase : IGetCursoByIdUseCase
    //{
    //    private readonly ICursoRepository _cursoRepository;
    //    private readonly IMapper _mapper;

    //    public GetCursoByIdUseCase(ICursoRepository cursoRepository,
    //        IMapper mapper)
    //    {
    //        _cursoRepository = cursoRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task<ResponseCursoJson> Execute(int id)
    //    {
    //        var result = await _cursoRepository.GetByIdAsync(id);

    //        if (result is null)
    //            throw new NotFoundException("Curso não encontrado");

    //        return _mapper.Map<ResponseCursoJson>(result);
    //    }
    //}
}
