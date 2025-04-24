using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.Alternativas.Register
{
    internal class RegisterAlternativaUseCase : IRegisterAlternativaUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAlternativaRepository _alternativaRepository;
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterAlternativaUseCase(IMapper mapper,
            IAlternativaRepository alternativaRepository,
            IQuestaoRepository questaoRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _alternativaRepository = alternativaRepository;
            _questaoRepository = questaoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseAlternativaJson> Execute(RequestRegisterAlternativaJson request)
        {
            await Validate(request);

            var alternativa = _mapper.Map<Alternativa>(request);

            await _alternativaRepository.SaveAsync(alternativa);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseAlternativaJson>(alternativa);
        }

        private async Task Validate(RequestRegisterAlternativaJson request)
        {
            var result = new RegisterAlternativaValidator().Validate(request);

            var existsQuestao = await _questaoRepository.ExistsWithIdAsync(request.QuestaoId);
            if (!existsQuestao)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A questão informada não foi encontrada"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }


    }
}
