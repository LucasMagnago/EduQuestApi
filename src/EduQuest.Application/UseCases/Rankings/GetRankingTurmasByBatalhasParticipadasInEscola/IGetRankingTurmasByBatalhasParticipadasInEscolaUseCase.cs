using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingTurmasByBatalhasParticipadasInEscola
{
    public interface IGetRankingTurmasByBatalhasParticipadasInEscolaUseCase
    {
        Task<List<ResponseTurmaRankingJson>> Execute(int escolaId);
    }
}
