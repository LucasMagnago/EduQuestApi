using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Conquistas.GetAll
{
    public interface IGetAllConquistaUseCase
    {
        Task<List<ResponseConquistaJson>> Execute();
    }
}
