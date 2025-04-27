using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.Questoes.SetCorrectAlternativa
{
    internal class SetQuestaoCorrectAlternativaUseCase : ISetQuestaoCorrectAlternativaUseCase
    {
        private readonly IMapper _mapper;
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IAlternativaRepository _alternativaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetQuestaoCorrectAlternativaUseCase(IMapper mapper,
            IQuestaoRepository questaoRepository,
            IAlternativaRepository alternativaRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _questaoRepository = questaoRepository;
            _alternativaRepository = alternativaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(int questaoId, RequestSetQuestaoCorrectAlternativaJson request)
        {
            await Validate(questaoId, request);

            var questao = await _questaoRepository.GetByIdAsync(questaoId);
            _mapper.Map(request, questao);

            await _questaoRepository.UpdateAsync(questao!);
            await _unitOfWork.Commit();
        }

        private async Task Validate(int questaoId, RequestSetQuestaoCorrectAlternativaJson request)
        {
            var result = new SetQuestaoCorrectAlternativaValidator().Validate(request);

            var existsQuestao = await _questaoRepository.ExistsWithIdAsync(questaoId);
            if (!existsQuestao)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A questão informada não foi encontrada"));
            }

            var existsAlternativa = await _alternativaRepository.ExistsWithIdAsync(request.AlternativaId);
            if (!existsAlternativa)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A alternativa informada não foi encontrada"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
