using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Turmas.GetAll
{
    public interface IGetAllTurmaUseCase
    {
        Task<List<ResponseTurmaJson>> Execute();
    }
}
