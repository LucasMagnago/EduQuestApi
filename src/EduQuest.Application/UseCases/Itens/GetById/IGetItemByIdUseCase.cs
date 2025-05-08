using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Itens.GetById
{
    public interface IGetItemByIdUseCase
    {
        Task<ResponseItemJson> Execute(int itemId);
    }
}
