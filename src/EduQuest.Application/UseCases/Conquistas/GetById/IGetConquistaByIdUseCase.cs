using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Conquistas.GetById
{
    public interface IGetConquistaByIdUseCase
    {
        Task<ResponseConquistaJson> Execute(int conquistaId);
    }
}
