using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;

namespace EduQuest.Application.UseCases.Rankings.GetRankingAlunosByMediaNotasInTurma
{
    internal class GetRankingAlunosByMediaNotasInTurmaUseCase : IGetRankingAlunosByMediaNotasInTurmaUseCase
    {
        private readonly IRankingRepository _rankingRepository;
        private readonly IMapper _mapper;

        public GetRankingAlunosByMediaNotasInTurmaUseCase(IRankingRepository rankingRepository,
            IMapper mapper)
        {
            _rankingRepository = rankingRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseAlunoRankingJson>> Execute(int turmaId)
        {
            var ranking = await _rankingRepository.GetRankingAlunosByMediaNotasInTurma(turmaId);
            if (ranking == null || ranking.Count == 0)
            {
                return new List<ResponseAlunoRankingJson>();
            }

            return _mapper.Map<List<ResponseAlunoRankingJson>>(ranking);
        }
    }
}
