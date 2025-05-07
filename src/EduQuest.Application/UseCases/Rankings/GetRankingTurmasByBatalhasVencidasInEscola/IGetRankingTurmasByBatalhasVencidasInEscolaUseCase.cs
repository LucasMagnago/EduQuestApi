using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Rankings.GetRankingTurmasByBatalhasVencidasInEscola
{
    public interface IGetRankingTurmasByBatalhasVencidasInEscolaUseCase
    {
        Task<List<ResponseTurmaRankingJson>> Execute(int escolaId);
    }
}
