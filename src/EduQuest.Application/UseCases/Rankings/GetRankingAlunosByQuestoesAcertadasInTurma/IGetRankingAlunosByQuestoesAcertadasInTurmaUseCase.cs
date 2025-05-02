using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingAlunosByQuestoesAcertadasInTurma
{
    public interface IGetRankingAlunosByQuestoesAcertadasInTurmaUseCase
    {
        Task<List<ResponseAlunoRankingJson>> Execute(int turmaId);
    }
}
