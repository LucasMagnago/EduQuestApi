using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;

namespace EduQuest.Application.UseCases.Rankings.GetRankingEscolasByAtividadesConcluidas
{
    internal class GetRankingEscolasByAtividadesConcluidasUseCase : IGetRankingEscolasByAtividadesConcluidasUseCase
    {
        private readonly IRankingRepository _rankingRepository;
        private readonly IMapper _mapper;

        public GetRankingEscolasByAtividadesConcluidasUseCase(IRankingRepository rankingRepository,
            IMapper mapper)
        {
            _rankingRepository = rankingRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseEscolaRankingJson>> Execute()
        {
            var ranking = await _rankingRepository.GetRankingEscolasByAtividadesConcluidas();
            if (ranking == null || ranking.Count == 0)
            {
                return new List<ResponseEscolaRankingJson>();
            }

            return _mapper.Map<List<ResponseEscolaRankingJson>>(ranking);
        }
    }
}
