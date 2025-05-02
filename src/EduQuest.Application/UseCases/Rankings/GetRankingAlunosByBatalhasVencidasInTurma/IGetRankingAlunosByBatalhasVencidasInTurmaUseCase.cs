using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingAlunosByBatalhasVencidasInTurma
{
    public interface IGetRankingAlunosByBatalhasVencidasInTurmaUseCase
    {
        Task<List<ResponseAlunoRankingJson>> Execute(int turmaId);
    }
}
