using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.AtividadeTurmas.Assign
{
    internal class AssignAtividadeToTurmaUseCase : IAssignAtividadeToTurmaUseCase
    {
        public readonly IMapper _mapper;
        public readonly IAtividadeTurmaRepository _atividadeTurmaRepository;
        public readonly ITurmaRepository _turmaRepository;
        public readonly IDisciplinaRepository _disciplinaRepository;
        public readonly IUnitOfWork _unitOfWork;

        public AssignAtividadeToTurmaUseCase(
            IMapper mapper,
            IAtividadeTurmaRepository atividadeTurmaRepository,
            ITurmaRepository turmaRepository,
            IDisciplinaRepository disciplinaRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _atividadeTurmaRepository = atividadeTurmaRepository;
            _turmaRepository = turmaRepository;
            _disciplinaRepository = disciplinaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseAssignedAtividadeToTurmaJson> Execute(RequestAssignAtividadeToTurmaJson request)
        {
            await Validate(request);

            var atividadeTurma = _mapper.Map<AtividadeTurma>(request);

            await _atividadeTurmaRepository.SaveAsync(atividadeTurma);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseAssignedAtividadeToTurmaJson>(atividadeTurma);
        }

        private async Task Validate(RequestAssignAtividadeToTurmaJson request)
        {
            var result = new AssignAtividadeToTurmaValidator().Validate(request);

            var existsAtividade = await _atividadeTurmaRepository.ExistsWithIdAsync(request.AtividadeId);
            if (!existsAtividade)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "Atividade informada não foi encontrada"));
            }

            var existsTurma = await _turmaRepository.ExistsWithIdAsync(request.TurmaId);
            if (!existsTurma)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "Turma informada não foi encontrada"));
            }

            var existsDisciplina = await _disciplinaRepository.ExistsWithIdAsync(request.DisciplinaId);
            if (!existsDisciplina)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "Disciplina não foi encontrada"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
