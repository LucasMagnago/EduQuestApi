using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Questoes.GetAllByProfessorId
{
    public interface IGetAllQuestaoByProfessorIdUseCase
    {
        Task<List<ResponseQuestaoJson>> Execute(int professorId);
    }
}
