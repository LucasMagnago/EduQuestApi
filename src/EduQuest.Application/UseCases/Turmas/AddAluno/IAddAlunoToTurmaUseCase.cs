using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Turmas.AddAluno
{
    public interface IAddAlunoToTurmaUseCase
    {
        Task<ResponseAlunoJson> Execute(RequestAddAlunoToTurmaJson request);
    }
}
