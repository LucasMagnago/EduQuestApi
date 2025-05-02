using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingAlunosByMediaNotaInTurma
{
    public interface IGetRankingAlunosByMediaNotaInTurmaUseCase
    {
        Task<List<ResponseAlunoRankingJson>> Execute(int turmaId);
    }
}
