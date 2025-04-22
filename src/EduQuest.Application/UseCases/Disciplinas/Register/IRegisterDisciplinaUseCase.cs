using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Disciplinas.Register
{
    public interface IRegisterDisciplinaUseCase
    {
        Task<ResponseRegisteredDisciplinaJson> Execute(RequestRegisterDisciplinaJson request);
    }
}
