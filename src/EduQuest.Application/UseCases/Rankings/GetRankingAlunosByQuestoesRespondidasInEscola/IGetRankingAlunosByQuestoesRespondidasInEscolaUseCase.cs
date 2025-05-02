using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingAlunosByQuestoesRespondidasInEscola
{
    public interface IGetRankingAlunosByQuestoesRespondidasInEscolaUseCase
    {
        Task<List<ResponseAlunoRankingJson>> Execute(int escolaId);
    }
}
