using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.Turmas.RemoveAluno
{
    internal class RemoveAlunoFromTurmaUseCase : IRemoveAlunoFromTurmaUseCase
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RemoveAlunoFromTurmaUseCase(IAlunoRepository alunoRepository,
            ITurmaRepository turmaRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseAlunoJson> Execute(RequestRemoveAlunoFromTurmaJson request)
        {
            await Validate(request);

            var aluno = await _alunoRepository.GetByIdAsync(request.AlunoId);
            aluno!.TurmaId = null;

            await _alunoRepository.UpdateAsync(aluno);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseAlunoJson>(aluno);
        }

        private async Task Validate(RequestRemoveAlunoFromTurmaJson request)
        {
            var result = new RemoveAlunoFromTurmaValidator().Validate(request);

            var existsAluno = await _alunoRepository.ExistsWithIdAsync(request.AlunoId);
            if (!existsAluno)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "O aluno informado não foi encontrado"));
            }

            var existsTurma = await _turmaRepository.ExistsWithIdAsync(request.TurmaId);
            if (!existsTurma)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A turma informada não foi encontrada"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
