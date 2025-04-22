using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Turmas.RemoveAluno
{
    public interface IRemoveAlunoFromTurmaUseCase
    {
        Task<ResponseAlunoJson> Execute(RequestRemoveAlunoFromTurmaJson request);
    }
}
