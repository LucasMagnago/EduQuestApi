using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingAlunosByMediaNotaInEscola
{
    public interface IGetRankingAlunosByMediaNotaInEscolaUseCase
    {
        Task<List<ResponseAlunoRankingJson>> Execute(int escolaId);
    }
}
