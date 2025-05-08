using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Itens.GetAll
{
    public interface IGetAllItem
    {
        Task<List<ResponseItemJson>> Execute();
    }
}
