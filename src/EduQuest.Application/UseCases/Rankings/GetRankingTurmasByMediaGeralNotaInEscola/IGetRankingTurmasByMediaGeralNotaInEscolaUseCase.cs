using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingTurmasByMediaGeralNotaInEscola
{
    public interface IGetRankingTurmasByMediaGeralNotaInEscolaUseCase
    {
        Task<List<ResponseTurmaRankingJson>> Execute(int escolaId);
    }
}
