namespace EduQuest.Application.UseCases.PeriodosLetivos.Register
{
    //internal class RegisterPeriodoLetivoUseCase : IRegisterPeriodoLetivoUseCase
    //{
    //    private readonly IMapper _mapper;
    //    //private readonly IPeriodoLetivoRepository _periodoLetivoRepository;
    //    private readonly IEscolaRepository _escolaRepository;
    //    private readonly IUnitOfWork _unitOfWork;

    //    public RegisterPeriodoLetivoUseCase(IMapper mapper,
    //        //IPeriodoLetivoRepository periodoLetivoRepository,
    //        IEscolaRepository escolaRepository,
    //        IUnitOfWork unitOfWork)
    //    {
    //        _mapper = mapper;
    //        //_periodoLetivoRepository = periodoLetivoRepository;
    //        _escolaRepository = escolaRepository;
    //        _unitOfWork = unitOfWork;
    //    }

    //    public async Task<ResponseRegisteredPeriodoLetivoJson> Execute(RequestRegisterPeriodoLetivoJson request)
    //    {
    //        await Validate(request);

    //        var periodoLetivo = _mapper.Map<PeriodoLetivo>(request);

    //        await _periodoLetivoRepository.SaveAsync(periodoLetivo);
    //        await _unitOfWork.Commit();

    //        return _mapper.Map<ResponseRegisteredPeriodoLetivoJson>(periodoLetivo);
    //    }

    //    private async Task Validate(RequestRegisterPeriodoLetivoJson request)
    //    {
    //        var result = new RegisterPeriodoLetivoValidator().Validate(request);

    //        var existsEscola = await _escolaRepository.ExistsWithIdAsync(request.EscolaId);
    //        if (!existsEscola)
    //        {
    //            result.Errors.Add(new ValidationFailure(string.Empty, "A escola informada não foi encontrada"));
    //        }

    //        if (request.DataInicio > request.DataFim)
    //        {
    //            result.Errors.Add(new ValidationFailure(string.Empty, "A data inicial não pode ser posterior a data final"));
    //        }

    //        if (result.IsValid == false)
    //        {
    //            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

    //            throw new ErrorOnValidationException(errorMessages);
    //        }
    //    }
    //}
}
