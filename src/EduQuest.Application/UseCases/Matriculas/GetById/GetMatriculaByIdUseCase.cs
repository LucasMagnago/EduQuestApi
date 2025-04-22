namespace EduQuest.Application.UseCases.Matriculas.GetById
{
    //public class GetMatriculaByIdUseCase : IGetMatriculaByIdUseCase
    //{
    //    private readonly IMatriculaRepository _matriculaRepository;
    //    private readonly IMapper _mapper;

    //    public GetMatriculaByIdUseCase(IMatriculaRepository matriculaRepository, IMapper mapper)
    //    {
    //        _matriculaRepository = matriculaRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task<ResponseMatriculaJson> Execute(int id)
    //    {
    //        var result = await _matriculaRepository.GetByIdAsync(id);

    //        if (result is null)
    //            throw new NotFoundException("Matrícula não encontrada");

    //        return _mapper.Map<ResponseMatriculaJson>(result);
    //    }
    //}
}
