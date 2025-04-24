using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Atividades.GetAllAvailableAtividadeByTurmaIdUseCase.cs
{
    public interface IGetAllAvailableAtividadeByTurmaIdUseCase
    {
        Task<List<ResponseAtividadeJson>> Execute(int turmaId);
    }
}
