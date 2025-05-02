using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingAlunosByAtividadeConcluidaInEscola
{
    public interface IGetRankingAlunosByAtividadeConcluidaInEscolaUseCase
    {
        Task<List<ResponseAlunoRankingJson>> Execute(int escolaId);
    }
}
