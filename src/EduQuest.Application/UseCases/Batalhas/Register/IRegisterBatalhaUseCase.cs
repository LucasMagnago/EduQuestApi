using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Batalhas.Register
{
    public interface IRegisterBatalhaUseCase
    {
        Task<ResponseBatalhaJson> Execute(RequestRegisterBatalhaJson request);
    }
}
