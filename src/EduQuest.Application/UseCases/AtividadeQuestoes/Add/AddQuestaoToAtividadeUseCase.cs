using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.AtividadeQuestoes.Register
{
    internal class AddQuestaoToAtividadeUseCase : IAddQuestaoToAtividadeUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAtividadeQuestaoRepository _atividadeQuestaoRepository;
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddQuestaoToAtividadeUseCase(IMapper mapper,
            IAtividadeQuestaoRepository atividadeQuestaoRepository,
            IAtividadeRepository atividadeRepository,
            IQuestaoRepository questaoRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _atividadeQuestaoRepository = atividadeQuestaoRepository;
            _atividadeRepository = atividadeRepository;
            _questaoRepository = questaoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseAtividadeQuestaoJson> Execute(RequestAddQuestaoToAtividadeJson request)
        {
            await Validate(request);

            var atividadeQuestao = _mapper.Map<AtividadeQuestao>(request);

            await _atividadeQuestaoRepository.SaveAsync(atividadeQuestao);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseAtividadeQuestaoJson>(atividadeQuestao);
        }

        private async Task Validate(RequestAddQuestaoToAtividadeJson request)
        {
            var result = new AddQuestaoToAtividadeValidator().Validate(request);

            bool existsAtividadeQuestao = await _atividadeQuestaoRepository.HasQuestionBeenAddedToActivity(request.AtividadeId, request.QuestaoId);
            if (existsAtividadeQuestao)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A questão informada já foi adicionada para esta atividade"));
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

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
