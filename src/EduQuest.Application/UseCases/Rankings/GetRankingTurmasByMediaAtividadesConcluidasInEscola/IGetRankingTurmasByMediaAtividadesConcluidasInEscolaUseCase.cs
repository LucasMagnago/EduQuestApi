using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingTurmasByMediaAtividadesConcluidasInEscola
{
    public interface IGetRankingTurmasByMediaAtividadesConcluidasInEscolaUseCase
    {
        Task<List<ResponseTurmaRankingJson>> Execute(int escolaId);
    }
}
