using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingAlunosByQuestoesAcertadasInEscola
{
    public interface IGetRankingAlunosByQuestoesAcertadasInEscolaUseCase
    {
        Task<List<ResponseAlunoRankingJson>> Execute(int escolaId);
    }
}
