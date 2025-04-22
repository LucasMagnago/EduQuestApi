using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Disciplinas.Register
{
    internal class RegisterDisciplinaUseCase : IRegisterDisciplinaUseCase
    {
        private readonly IMapper _mapper;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterDisciplinaUseCase(IMapper mapper,
            IDisciplinaRepository disciplinaRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _disciplinaRepository = disciplinaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisteredDisciplinaJson> Execute(RequestRegisterDisciplinaJson request)
        {
            await Validate(request);

            var disciplina = _mapper.Map<Disciplina>(request);

            await _disciplinaRepository.SaveAsync(disciplina);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseRegisteredDisciplinaJson>(disciplina);
        }

        private async Task Validate(RequestRegisterDisciplinaJson request)
        {
            var result = new RegisterDisciplinaValidator().Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
