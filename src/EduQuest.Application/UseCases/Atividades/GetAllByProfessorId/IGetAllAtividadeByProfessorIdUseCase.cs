using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Atividades.GetAllByProfessorId
{
    public interface IGetAllAtividadeByProfessorIdUseCase
    {
        Task<List<ResponseAtividadeJson>> Execute(int professorId);
    }
}
