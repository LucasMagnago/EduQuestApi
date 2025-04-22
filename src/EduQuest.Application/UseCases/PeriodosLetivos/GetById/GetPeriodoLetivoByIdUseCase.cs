namespace EduQuest.Application.UseCases.PeriodosLetivos.GetById
{
    //public class GetPeriodoLetivoByIdUseCase : IGetPeriodoLetivoByIdUseCase
    //{
    //    private readonly IPeriodoLetivoRepository _periodoLetivoRepository;
    //    private readonly IMapper _mapper;

    //    public GetPeriodoLetivoByIdUseCase(IPeriodoLetivoRepository periodoLetivoRepository,
    //        IMapper mapper)
    //    {
    //        _periodoLetivoRepository = periodoLetivoRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task<ResponsePeriodoLetivoJson> Execute(int id)
    //    {
    //        var result = await _periodoLetivoRepository.GetByIdAsync(id);

    //        if (result is null)
    //            throw new NotFoundException("Periodo letivo não encontrado");

    //        return _mapper.Map<ResponsePeriodoLetivoJson>(result);
    //    }
    //}
}
