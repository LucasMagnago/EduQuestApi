using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Questoes.GetAllByDisciplinaIdAndNivel
{
    public interface IGetAllQuestaoByDisciplinaIdAndNivelUseCase
    {
        Task<List<ResponseQuestaoJson>> Execute(int disciplinaId, int nivel);
    }
}
