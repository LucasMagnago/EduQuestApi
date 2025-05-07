using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingEscolasByMediaNotas
{
    public interface IGetRankingEscolasByMediaNotasUseCase
    {
        Task<List<ResponseEscolaRankingJson>> Execute();
    }
}
