using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Alternativas.GetById
{
    public class GetAlternativaByIdUseCase : IGetAlternativaByIdUseCase
    {
        private readonly IAlternativaRepository _alternativaRepository;
        private readonly IMapper _mapper;

        public GetAlternativaByIdUseCase(IAlternativaRepository alternativaRepository, IMapper mapper)
        {
            _alternativaRepository = alternativaRepository;
            _mapper = mapper;
        }

        public async Task<ResponseAlternativaJson> Execute(int alternativaId)
        {
            var alternativa = await _alternativaRepository.GetByIdAsync(alternativaId);
            if (alternativa == null)
            {
                throw new NotFoundException("Alternativa não encontrada");
            }

            return _mapper.Map<ResponseAlternativaJson>(alternativa);
        }
    }
}
