using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AtividadeQuestoes.Register
{
    public interface IAddQuestaoToAtividadeUseCase
    {
        Task<ResponseAtividadeQuestaoJson> Execute(RequestAddQuestaoToAtividadeJson request);
    }
}
