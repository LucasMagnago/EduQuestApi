using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;

namespace EduQuest.Application.UseCases.Rankings.GetRankingAlunosByBatalhasVencidasInEscola
{
    internal class GetRankingAlunosByBatalhasVencidasInEscolaUseCase : IGetRankingAlunosByBatalhasVencidasInEscolaUseCase
    {
        private readonly IRankingRepository _rankingRepository;
        private readonly IMapper _mapper;

        public GetRankingAlunosByBatalhasVencidasInEscolaUseCase(IRankingRepository rankingRepository,
            IMapper mapper)
        {
            _rankingRepository = rankingRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseAlunoRankingJson>> Execute(int escolaId)
        {
            var ranking = await _rankingRepository.GetRankingAlunosPorBatalhasVencidasNaEscola(escolaId);
            if (ranking == null || ranking.Count == 0)
            {
                return new List<ResponseAlunoRankingJson>();
            }

            return _mapper.Map<List<ResponseAlunoRankingJson>>(ranking);
        }
    }
}
