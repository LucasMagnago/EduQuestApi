namespace EduQuest.Application.UseCases.Matriculas.Transferir
{
    //public class RegisterTransferenciaUseCase : IRegisterTransferenciaUseCase
    //{
    //    private readonly IMapper _mapper;
    //    private readonly IMatriculaRepository _matriculaRepository;
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly ILoggedUser _loggedUser;

    //    public RegisterTransferenciaUseCase(IMapper mapper,
    //        IMatriculaRepository matriculaRepository,
    //        IUnitOfWork unitOfWork,
    //        ILoggedUser loggedUser)
    //    {
    //        _mapper = mapper;
    //        _matriculaRepository = matriculaRepository;
    //        _unitOfWork = unitOfWork;
    //        _loggedUser = loggedUser;
    //    }

    //    public async Task<ResponseRegisteredTransferenciaJson> Execute(int matriculaId)
    //    {
    //        var matricula = await _matriculaRepository.GetByIdAsync(matriculaId);

    //        if (matricula is null)
    //            throw new NotFoundException("A matrícula informada não foi encontrada");

    //        if (matricula.Situacao != SituacaoMatricula.Normal)
    //            throw new ErrorOnValidationException(new List<string>() { $"A situação da matrícula informada é {matricula.Situacao.ToString().ToLower()}" });

    //        matricula.Situacao = SituacaoMatricula.Transferido;
    //        matricula.DataSituacao = DateTime.Now;

    //        var loggedUser = await _loggedUser.Get();
    //        matricula.UsuarioSituacao = loggedUser;

    //        await _matriculaRepository.SaveAsync(matricula);
    //        await _unitOfWork.Commit();

    //        return _mapper.Map<ResponseRegisteredTransferenciaJson>(matricula);
    //    }
    //}
}
