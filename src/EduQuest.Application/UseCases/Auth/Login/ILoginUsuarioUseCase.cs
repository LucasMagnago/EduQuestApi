using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Auth.Login
{
    public interface ILoginUsuarioUseCase
    {
        Task<ResponseLoggedUsuarioJson> Execute(RequestLoginUsuarioJson request);
    }
}
