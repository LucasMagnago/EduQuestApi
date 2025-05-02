using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.Turmas.Register
{
    internal class RegisterTurmaUseCase : IRegisterTurmaUseCase
    {
        private readonly IMapper _mapper;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IEscolaRepository _escolaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterTurmaUseCase(IMapper mapper,
            ITurmaRepository turmaRepository,
            IEscolaRepository escolaRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _turmaRepository = turmaRepository;
            _escolaRepository = escolaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisteredTurmaJson> Execute(RequestRegisterTurmaJson request)
        {
            await Validate(request);

            var turma = _mapper.Map<Turma>(request);
            turma.Ativo = true;

            await _turmaRepository.SaveAsync(turma);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseRegisteredTurmaJson>(turma);
        }

        private async Task Validate(RequestRegisterTurmaJson request)
        {
            var result = new RegisterTurmaValidator().Validate(request);

            var existsEscola = await _escolaRepository.ExistsWithIdAsync(request.EscolaId);
            if (!existsEscola)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A escola informada não foi encontrada"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
