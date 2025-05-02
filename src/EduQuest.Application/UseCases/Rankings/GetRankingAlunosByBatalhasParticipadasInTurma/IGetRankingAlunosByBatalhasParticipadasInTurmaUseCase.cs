using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingAlunosByBatalhasParticipadasInTurma
{
    public interface IGetRankingAlunosByBatalhasParticipadasInTurmaUseCase
    {
        Task<List<ResponseAlunoRankingJson>> Execute(int turmaId);
    }
}
