using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingEscolasByBatalhasVencidas
{
    public interface IGetRankingEscolasByBatalhasVencidasUseCase
    {
        Task<List<ResponseEscolaRankingJson>> Execute();
    }
}
