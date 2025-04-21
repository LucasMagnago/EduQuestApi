using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Auth.Register
{
    public interface IRegisterUsuarioUseCase
    {
        Task<ResponseRegisteredUsuarioJson> Execute(RequestRegisterUsuarioJson request);
    }
}
