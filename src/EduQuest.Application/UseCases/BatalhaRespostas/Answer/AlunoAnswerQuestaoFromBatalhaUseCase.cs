using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.BatalhaRespostas.Answer
{
    internal class AlunoAnswerQuestaoFromBatalhaUseCase : IAlunoAnswerQuestaoFromBatalhaUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBatalhaRespostaRepository _batalhaRespostaRepository;
        private readonly IBatalhaRepository _batalhaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IAlternativaRepository _alternativaRepository;
        private readonly IMapper _mapper;

        public AlunoAnswerQuestaoFromBatalhaUseCase(IUnitOfWork unitOfWork,
            IBatalhaRespostaRepository batalhaRespostaRepository,
            IBatalhaRepository batalhaRepository,
            IAlunoRepository alunoRepository,
            IQuestaoRepository questaoRepository,
            IAlternativaRepository alternativaRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _batalhaRespostaRepository = batalhaRespostaRepository;
            _batalhaRepository = batalhaRepository;
            _alunoRepository = alunoRepository;
            _questaoRepository = questaoRepository;
            _alternativaRepository = alternativaRepository;
            _mapper = mapper;
        }

        public async Task<ResponseBatalhaRespostaJson> Execute(RequestAlunoAnswerQuestaoFromBatalhaJson request)
        {
            await Validate(request);

            var batalhaResposta = await _batalhaRespostaRepository
                .GetBatalhaRespostaByAlunoIdAndBatalhaIdAndQuestaoIdAsync(request.AlunoId, request.BatalhaId, request.QuestaoId);

            var questao = await _questaoRepository.GetByIdAsync(request.QuestaoId);

            bool acertou = questao!.IsCorrectAnswer(request.AlternativaEscolhaId);

            if (batalhaResposta == null)
            {
                batalhaResposta = new BatalhaResposta
                {
                    AlunoId = request.AlunoId,
                    BatalhaId = request.BatalhaId,
                    QuestaoId = request.QuestaoId,
                    Acertou = acertou,
                    AlternativaEscolhaId = request.AlternativaEscolhaId,
                    DataResposta = DateTime.Now
                };

                await _batalhaRespostaRepository.SaveAsync(batalhaResposta);
            }
            else
            {
                batalhaResposta.Acertou = acertou;
                batalhaResposta.AlternativaEscolhaId = request.AlternativaEscolhaId;
                batalhaResposta.DataResposta = DateTime.Now;

                await _batalhaRespostaRepository.UpdateAsync(batalhaResposta);
            }

            await _unitOfWork.Commit();

            return _mapper.Map<ResponseBatalhaRespostaJson>(batalhaResposta);
        }

        private async Task Validate(RequestAlunoAnswerQuestaoFromBatalhaJson request)
        {
            var result = new AlunoAnswerQuestaoFromBatalhaValidator().Validate(request);

            bool alunoExists = await _alunoRepository.ExistsWithIdAsync(request.AlunoId);
            if (!alunoExists)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "O aluno informado não existe"));
            }

            bool batalhaExists = await _batalhaRepository.ExistsWithIdAsync(request.BatalhaId);
            if (!batalhaExists)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A batalha informada não existe"));
            }

            bool questaoExists = await _questaoRepository.ExistsWithIdAsync(request.QuestaoId);
            if (!questaoExists)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A questão informada não existe"));
            }

            bool alternativaExists = await _alternativaRepository.ExistsWithIdAsync(request.AlternativaEscolhaId);
            if (!alunoExists)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A alternativa informada não existe"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}

