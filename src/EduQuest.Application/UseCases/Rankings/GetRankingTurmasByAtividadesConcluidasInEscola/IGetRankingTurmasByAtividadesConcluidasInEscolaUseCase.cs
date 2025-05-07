using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingTurmasByAtividadesConcluidasInEscola
{
    public interface IGetRankingTurmasByAtividadesConcluidasInEscolaUseCase
    {
        Task<List<ResponseTurmaRankingJson>> Execute(int escolaId);
    }
}
