using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Atividades.GetAllByTurmaId
{
    public interface IGetAllAtividadeByTurmaIdUseCase
    {
        Task<List<ResponseAtividadeJson>> Execute(int turmaId);
    }
}
