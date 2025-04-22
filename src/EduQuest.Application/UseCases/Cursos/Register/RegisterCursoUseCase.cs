namespace EduQuest.Application.UseCases.Cursos.Register
{
    //internal class RegisterCursoUseCase : IRegisterCursoUseCase
    //{
    //    private readonly IMapper _mapper;
    //    private readonly ICursoRepository _cursoRepository;
    //    private readonly IUnitOfWork _unitOfWork;

    //    public RegisterCursoUseCase(IMapper mapper,
    //        ICursoRepository cursoRepository,
    //        IUnitOfWork unitOfWork)
    //    {
    //        _mapper = mapper;
    //        _cursoRepository = cursoRepository;
    //        _unitOfWork = unitOfWork;
    //    }

    //    public async Task<ResponseRegisteredCursoJson> Execute(RequestRegisterCursoJson request)
    //    {
    //        await Validate(request);

    //        var curso = _mapper.Map<Curso>(request);

    //        await _cursoRepository.SaveAsync(curso);
    //        await _unitOfWork.Commit();

    //        return _mapper.Map<ResponseRegisteredCursoJson>(curso);
    //    }

    //    private async Task Validate(RequestRegisterCursoJson request)
    //    {
    //        var result = new RegisterCursoValidator().Validate(request);

    //        if (result.IsValid == false)
    //        {
    //            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

    //            throw new ErrorOnValidationException(errorMessages);
    //        }
    //    }
    //}
}
