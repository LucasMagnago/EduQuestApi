using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AtividadeTurmas.Unassign
{
    public interface IUnassignAtividadeFromTurmaUseCase
    {
        Task<ResponseUnassignedAtividadeFromTurmaJson> Execute(int atividadeTurmaId);
    }
}
