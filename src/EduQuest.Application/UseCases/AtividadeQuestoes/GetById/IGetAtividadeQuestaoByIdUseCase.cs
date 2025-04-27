using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AtividadeQuestoes.GetById
{
    public interface IGetAtividadeQuestaoByIdUseCase
    {
        Task<ResponseAtividadeQuestaoJson> Execute(int id);
    }
}
