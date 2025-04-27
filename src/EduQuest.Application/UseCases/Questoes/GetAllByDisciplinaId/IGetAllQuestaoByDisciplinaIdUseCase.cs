using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Questoes.GetAllByDisciplinaId
{
    public interface IGetAllQuestaoByDisciplinaIdUseCase
    {
        Task<List<ResponseQuestaoJson>> Execute(int disciplinaId);
    }
}
