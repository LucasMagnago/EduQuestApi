using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Batalhas.AddAluno
{
    public interface IAddAlunoToBatalhaUseCase
    {
        Task<ResponseBatalhaJson> Execute(RequestAddAlunoToBatalhaJson request);
    }
}
