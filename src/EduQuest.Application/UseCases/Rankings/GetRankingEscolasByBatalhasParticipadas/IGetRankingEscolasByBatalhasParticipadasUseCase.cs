using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingEscolasByBatalhasParticipadas
{
    public interface IGetRankingEscolasByBatalhasParticipadasUseCase
    {
        Task<List<ResponseEscolaRankingJson>> Execute();
    }
}
