using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Enums;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.AtividadeAlunos.Start
{
    internal class AlunoStartsAtividadeUseCase : IAlunoStartsAtividadeUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAtividadeAlunoRepository _atividadeAlunoRepository;
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoStartsAtividadeUseCase(IMapper mapper,
            IAtividadeAlunoRepository atividadeAlunoRepository,
            IAtividadeRepository atividadeRepository,
            IAlunoRepository alunoRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _atividadeAlunoRepository = atividadeAlunoRepository;
            _atividadeRepository = atividadeRepository;
            _alunoRepository = alunoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseAtividadeAlunoJson> Execute(RequestAlunoStartsAtividadeJson request)
        {
            await Validate(request);

            var atividadeAluno = _mapper.Map<AtividadeAluno>(request);
            atividadeAluno.Status = StatusAtividade.Iniciada;
            atividadeAluno.DataInicio = DateTime.Now;

            await _atividadeAlunoRepository.SaveAsync(atividadeAluno);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseAtividadeAlunoJson>(request);
        }

        private async Task Validate(RequestAlunoStartsAtividadeJson request)
        {
            var result = new AlunoStartsAtividadeValidator().Validate(request);

            bool existsAluno = await _alunoRepository.ExistsWithIdAsync(request.AlunoId);
            if (!existsAluno)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "O aluno informado não existe"));
            }

            bool existsAtividade = await _atividadeRepository.ExistsWithIdAsync(request.AtividadeId);
            if (!existsAtividade)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A atividade informada não existe"));
            }

            bool alunoAlreadyStarted = await _atividadeAlunoRepository.CheckIfAlunoAlreadyStartedAtividade(request.AlunoId, request.AtividadeId);
            if (!alunoAlreadyStarted)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "O aluno já iniciou esta atividade"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
