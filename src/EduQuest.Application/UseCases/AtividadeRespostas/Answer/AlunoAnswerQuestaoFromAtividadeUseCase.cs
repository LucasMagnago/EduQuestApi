using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.AtividadeRespostas.Answer
{
    internal class AlunoAnswerQuestaoFromAtividadeUseCase : IAlunoAnswerQuestaoFromAtividadeUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAtividadeAlunoRepository _atividadeAlunoRepository;
        private readonly IAtividadeRespostaRepository _atividadeRespostaRepository;
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoAnswerQuestaoFromAtividadeUseCase(IMapper mapper,
            IAtividadeAlunoRepository atividadeAlunoRepository,
            IAtividadeRepository atividadeRepository,
            IAtividadeRespostaRepository atividadeRespostaRepository,
            IAlunoRepository alunoRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _atividadeAlunoRepository = atividadeAlunoRepository;
            _atividadeRespostaRepository = atividadeRespostaRepository;
            _atividadeRepository = atividadeRepository;
            _alunoRepository = alunoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseAtividadeRespostaJson> Execute(RequestAlunoAnswerQuestaoFromAtividadeJson request)
        {
            await Validate(request);

            var atividadeAluno = _atividadeAlunoRepository.GetByAlunoIdAndAtividadeId(request.AlunoId, request.AtividadeId);
            var atividadeResposta = _mapper.Map<AtividadeResposta>(request);

            atividadeResposta.AtividadeAlunoId = atividadeAluno.Id;
            atividadeResposta.AlternativaEscolhaId = request.AlternativaEscolhaId;
            atividadeResposta.DataResposta = DateTime.Now;

            await _atividadeRespostaRepository.SaveAsync(atividadeResposta);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseAtividadeRespostaJson>(atividadeResposta);
        }


        private async Task Validate(RequestAlunoAnswerQuestaoFromAtividadeJson request)
        {
            var result = new AlunoAnswerQuestaoFromAtividadeValidator().Validate(request);

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

            bool existsQuestao = await _atividadeRepository.ExistsWithIdAsync(request.QuestaoId);
            if (!existsQuestao)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A questão informada não existe"));
            }

            bool existsAlternativaEscolha = await _atividadeRepository.ExistsWithIdAsync(request.AlternativaEscolhaId);
            if (!existsAlternativaEscolha)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A alternativa escolhida informada não existe"));
            }

            bool existsAtividadeAluno = await _atividadeAlunoRepository.CheckIfAlunoAlreadyStartedAtividade(request.AlunoId, request.AtividadeId);
            if (!existsAtividadeAluno)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "O aluno informado não iniciou esta atividade"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
