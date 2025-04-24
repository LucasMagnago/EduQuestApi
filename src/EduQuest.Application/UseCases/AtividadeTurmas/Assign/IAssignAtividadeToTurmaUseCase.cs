using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AtividadeTurmas.Assign
{
    public interface IAssignAtividadeToTurmaUseCase
    {
        Task<ResponseAssignedAtividadeToTurmaJson> Execute(RequestAssignAtividadeToTurmaJson request);
    }
}
