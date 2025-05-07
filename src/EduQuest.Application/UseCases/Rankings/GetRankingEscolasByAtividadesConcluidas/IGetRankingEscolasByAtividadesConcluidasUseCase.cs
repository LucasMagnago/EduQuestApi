using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingEscolasByAtividadesConcluidas
{
    public interface IGetRankingEscolasByAtividadesConcluidasUseCase
    {
        Task<List<ResponseEscolaRankingJson>> Execute();
    }
}
