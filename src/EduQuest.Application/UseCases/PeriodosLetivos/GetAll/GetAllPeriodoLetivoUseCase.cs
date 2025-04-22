namespace EduQuest.Application.UseCases.PeriodosLetivos.GetAll
{
    //public class GetAllPeriodoLetivoUseCase : IGetAllPeriodoLetivoUseCase
    //{
    //    private readonly IPeriodoLetivoRepository _periodoLetivoRepository;
    //    private readonly IMapper _mapper;

    //    public GetAllPeriodoLetivoUseCase(IPeriodoLetivoRepository periodoLetivoRepository,
    //    IMapper mapper)
    //    {
    //        _periodoLetivoRepository = periodoLetivoRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task<List<ResponsePeriodoLetivoJson>> Execute()
    //    {
    //        var result = await _periodoLetivoRepository.GetAllAsync();

    //        if (result is null)
    //            throw new NotFoundException("Periodos letivos não encontrados");

    //        return _mapper.Map<List<ResponsePeriodoLetivoJson>>(result);
    //    }
    //}
}
