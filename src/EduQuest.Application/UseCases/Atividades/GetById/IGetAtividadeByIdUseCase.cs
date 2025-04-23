using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Atividades.GetById
{
    public interface IGetAtividadeByIdUseCase
    {
        Task<ResponseAtividadeJson> Execute(int id);
    }
}
