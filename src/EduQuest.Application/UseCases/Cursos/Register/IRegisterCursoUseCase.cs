using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Cursos.Register
{
    public interface IRegisterCursoUseCase
    {
        Task<ResponseRegisteredCursoJson> Execute(RequestRegisterCursoJson request);
    }
}
