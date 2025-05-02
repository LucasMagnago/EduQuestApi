using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingAlunosByAtividadeConcluidaInTurma
{
    public interface IGetRankingAlunosByAtividadeConcluidaInTurmaUseCase
    {
        Task<List<ResponseAlunoRankingJson>> Execute(int turmaId);
    }
}
