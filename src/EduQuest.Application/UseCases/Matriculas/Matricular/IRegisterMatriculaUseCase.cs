using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Matriculas.Matricular
{
    public interface IRegisterMatriculaUseCase
    {
        Task<ResponseRegisteredMatriculaJson> Execute(RequestRegisterMatriculaJson request);
    }
}
