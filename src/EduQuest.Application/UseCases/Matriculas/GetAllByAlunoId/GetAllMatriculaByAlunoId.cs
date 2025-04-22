namespace EduQuest.Application.UseCases.Matriculas.GetAllByAlunoId
{
    //internal class GetAllMatriculaByAlunoId : IGetAllMatriculaByAlunoId
    //{
    //    private readonly IMatriculaRepository _matriculaRepository;
    //    private readonly IMapper _mapper;

    //    public GetAllMatriculaByAlunoId(IMatriculaRepository matriculaRepository,
    //        IMapper mapper)
    //    {
    //        _matriculaRepository = matriculaRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task<List<ResponseMatriculaJson>> Execute(int alunoId)
    //    {
    //        var matriculas = await _matriculaRepository.GetAllByAlunoId(alunoId);
    //        if (matriculas is null)
    //            throw new NotFoundException("Matrículas não encontradas");

    //        return _mapper.Map<List<ResponseMatriculaJson>>(matriculas);
    //    }
    //}
}
