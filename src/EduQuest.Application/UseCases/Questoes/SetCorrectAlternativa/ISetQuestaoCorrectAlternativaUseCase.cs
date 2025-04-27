using EduQuest.Communication.Requests;

namespace EduQuest.Application.UseCases.Questoes.SetCorrectAlternativa
{
    public interface ISetQuestaoCorrectAlternativaUseCase
    {
        Task Execute(int questaoId, RequestSetQuestaoCorrectAlternativaJson request);
    }
}
