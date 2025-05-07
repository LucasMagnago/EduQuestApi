using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;

namespace EduQuest.Application.UseCases.Rankings.GetRankingTurmasByMediaNotasInEscola
{
    internal class GetRankingTurmasByMediaNotasInEscolaUseCase : IGetRankingTurmasByMediaNotasInEscolaUseCase
    {
        private readonly IRankingRepository _rankingRepository;
        private readonly IMapper _mapper;

        public GetRankingTurmasByMediaNotasInEscolaUseCase(IRankingRepository rankingRepository,
            IMapper mapper)
        {
            _rankingRepository = rankingRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseTurmaRankingJson>> Execute(int escolaId)
        {
            var ranking = await _rankingRepository.GetRankingTurmasByMediaNotasInEscola(escolaId);
            if (ranking == null || ranking.Count == 0)
            {
                return new List<ResponseTurmaRankingJson>();
            }

            return _mapper.Map<List<ResponseTurmaRankingJson>>(ranking);
        }
    }
}
