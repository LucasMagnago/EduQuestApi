using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Turmas.Register
{
    public interface IRegisterTurmaUseCase
    {
        Task<ResponseRegisteredTurmaJson> Execute(RequestRegisterTurmaJson request);
    }
}
