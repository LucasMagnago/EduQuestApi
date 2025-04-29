using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Batalhas.Start
{
    public interface IStartBatalhaUseCase
    {
        Task<ResponseBatalhaJson> Execute(RequestStartBatalhaJson request);
    }
}
