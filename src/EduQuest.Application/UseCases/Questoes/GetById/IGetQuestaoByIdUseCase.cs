using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Questoes.GetById
{
    public interface IGetQuestaoByIdUseCase
    {
        Task<ResponseQuestaoJson> Execute(int id);
    }
}
