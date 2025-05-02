using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;

namespace EduQuest.Application.UseCases.Rankings.GetRankingTurmasByMediaGeralNotaInEscola
{
    internal class GetRankingTurmasByMediaGeralNotaInEscolaUseCase : IGetRankingTurmasByMediaGeralNotaInEscolaUseCase
    {
        private readonly IRankingRepository _rankingRepository;
        private readonly IMapper _mapper;

        public GetRankingTurmasByMediaGeralNotaInEscolaUseCase(IRankingRepository rankingRepository,
            IMapper mapper)
        {
            _rankingRepository = rankingRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseTurmaRankingJson>> Execute(int escolaId)
        {
            var ranking = await _rankingRepository.GetRankingTurmasPorMediaGeralNotaNaEscola(escolaId);
            if (ranking == null || ranking.Count == 0)
            {
                return new List<ResponseTurmaRankingJson>();
            }

            return _mapper.Map<List<ResponseTurmaRankingJson>>(ranking);
        }
    }
}
