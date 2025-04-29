using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Batalhas.End
{
    public interface IEndBatalhaUseCase
    {
        Task<ResponseBatalhaJson> Execute(RequestEndBatalhaJson request);
    }
}
