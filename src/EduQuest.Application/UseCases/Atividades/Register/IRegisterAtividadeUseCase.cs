using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Atividades.Register
{
    public interface IRegisterAtividadeUseCase
    {
        Task<ResponseRegisteredAtividadeJson> Execute(RequestRegisterAtividadeJson request);
    }
}
