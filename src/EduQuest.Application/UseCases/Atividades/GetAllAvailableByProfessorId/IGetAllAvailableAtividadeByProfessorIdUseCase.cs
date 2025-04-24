using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Atividades.GetAllAvailableByProfessorId
{
    public interface IGetAllAvailableAtividadeByProfessorIdUseCase
    {
        Task<List<ResponseAtividadeJson>> Execute(int professorId);
    }
}
