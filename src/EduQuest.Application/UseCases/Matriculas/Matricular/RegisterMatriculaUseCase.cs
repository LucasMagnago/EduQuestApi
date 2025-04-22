namespace EduQuest.Application.UseCases.Matriculas.Matricular
{
    //internal class RegisterMatriculaUseCase : IRegisterMatriculaUseCase
    //{
    //    private readonly IMapper _mapper;
    //    private readonly IMatriculaRepository _matriculaRepository;
    //    private readonly IAlunoRepository _alunoRepository;
    //    private readonly IPeriodoLetivoRepository _periodoLetivoRepository;
    //    private readonly ITurmaRepository _turmaRepository;
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly ILoggedUser _loggedUser;

    //    public RegisterMatriculaUseCase(IMapper mapper,
    //        IMatriculaRepository matriculaRepository,
    //        IAlunoRepository alunoRepository,
    //        IPeriodoLetivoRepository periodoLetivoRepository,
    //        ITurmaRepository turmaRepository,
    //        IUnitOfWork unitOfWork,
    //        ILoggedUser loggedUser)
    //    {
    //        _mapper = mapper;
    //        _matriculaRepository = matriculaRepository;
    //        _alunoRepository = alunoRepository;
    //        _periodoLetivoRepository = periodoLetivoRepository;
    //        _turmaRepository = turmaRepository;
    //        _unitOfWork = unitOfWork;
    //        _loggedUser = loggedUser;
    //    }

    //    public async Task<ResponseRegisteredMatriculaJson> Execute(RequestRegisterMatriculaJson request)
    //    {
    //        await Validate(request);

    //        var matricula = _mapper.Map<Matricula>(request);
    //        matricula.Situacao = SituacaoMatricula.Normal;
    //        matricula.DataSituacao = DateTime.Now;
    //        matricula.DataMatricula = DateTime.Now;

    //        var loggedUser = await _loggedUser.Get();
    //        matricula.UsuarioCriacao = loggedUser;
    //        matricula.UsuarioSituacao = loggedUser;


    //        await _matriculaRepository.SaveAsync(matricula);
    //        await _unitOfWork.Commit();

    //        return _mapper.Map<ResponseRegisteredMatriculaJson>(matricula);
    //    }

    //    private async Task Validate(RequestRegisterMatriculaJson request)
    //    {
    //        var result = new RegisterMatriculaValidator().Validate(request);

    //        var existsAluno = await _alunoRepository.ExistsWithIdAsync(request.AlunoId);
    //        if (!existsAluno)
    //        {
    //            result.Errors.Add(new ValidationFailure(string.Empty, "O aluno informado não foi encontrado"));
    //        }

    //        var existsTurma = await _turmaRepository.ExistsWithIdAsync(request.TurmaId);
    //        if (!existsTurma)
    //        {
    //            result.Errors.Add(new ValidationFailure(string.Empty, "A turma informada não foi encontrada"));
    //        }

    //        var periodoLetivo = await _periodoLetivoRepository.GetByTurmaId(request.TurmaId);

    //        var existsMatriculaAtivaInPeriodoLetivo = await _matriculaRepository.ExistsMatriculaAtivaByAlunoIdAndPeriodoLetivoId(request.AlunoId, periodoLetivo.Id);
    //        if (existsMatriculaAtivaInPeriodoLetivo)
    //        {
    //            result.Errors.Add(new ValidationFailure(string.Empty, "O aluno já está matriculado nesse período letivo"));
    //        }

    //        if (result.IsValid == false)
    //        {
    //            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

    //            throw new ErrorOnValidationException(errorMessages);
    //        }
    //    }
    //}
}
