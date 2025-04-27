using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AtividadeQuestoes.GetAllByAtividadeId
{
    public interface IGetAllQuestaoByAtividadeIdUseCase
    {
        Task<List<ResponseQuestaoJson>> Execute(int atividadeId);
    }
}
