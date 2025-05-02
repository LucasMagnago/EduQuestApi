using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingAlunosByBatalhasParticipadasInEscola
{
    public interface IGetRankingAlunosByBatalhasParticipadasInEscolaUseCase
    {
        Task<List<ResponseAlunoRankingJson>> Execute(int escolaId);
    }
}
