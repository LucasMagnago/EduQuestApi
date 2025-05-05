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
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoAnswerQuestaoFromAtividadeUseCase(IMapper mapper,
            IAtividadeAlunoRepository atividadeAlunoRepository,
            IAtividadeRepository atividadeRepository,
            IAtividadeRespostaRepository atividadeRespostaRepository,
            IAlunoRepository alunoRepository,
            IQuestaoRepository questaoRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _atividadeAlunoRepository = atividadeAlunoRepository;
            _atividadeRespostaRepository = atividadeRespostaRepository;
            _atividadeRepository = atividadeRepository;
            _alunoRepository = alunoRepository;
            _questaoRepository = questaoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseAtividadeRespostaJson> Execute(RequestAlunoAnswerQuestaoFromAtividadeJson request)
        {
            await Validate(request);

            var atividadeAluno = await _atividadeAlunoRepository.GetByAlunoIdAndAtividadeId(request.AlunoId, request.AtividadeId);
            var atividadeResposta = await _atividadeRespostaRepository.GetByAtividadeAlunoIdAndQuestaoId(atividadeAluno!.Id, request.QuestaoId);

            bool isNewResposta = atividadeResposta == null;

            if (isNewResposta)
            {
                atividadeResposta = _mapper.Map<AtividadeResposta>(request);
                atividadeResposta.AtividadeAlunoId = atividadeAluno.Id;
                atividadeResposta.DataResposta = DateTime.Now;

                await _atividadeRespostaRepository.SaveAsync(atividadeResposta);
            }
            else
            {
                atividadeResposta!.AlternativaEscolhaId = request.AlternativaEscolhaId;
                atividadeResposta.DataResposta = DateTime.Now;

                await _atividadeRespostaRepository.UpdateAsync(atividadeResposta);
            }

            var questao = await _questaoRepository.GetByIdAsync(request.QuestaoId);
            bool acertou = questao!.IsCorrectAnswer(request.AlternativaEscolhaId);

            atividadeResposta.Acertou = acertou;

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

            bool existsQuestao = await _questaoRepository.ExistsWithIdAsync(request.QuestaoId);
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
