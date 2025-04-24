using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Questoes.Register
{
    public interface IRegisterQuestaoUseCase
    {
        Task<ResponseQuestaoJson> Execute(RequestRegisterQuestaoJson request);
    }
}
