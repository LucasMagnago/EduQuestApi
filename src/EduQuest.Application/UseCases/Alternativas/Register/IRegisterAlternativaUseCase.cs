using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Alternativas.Register
{
    public interface IRegisterAlternativaUseCase
    {
        Task<ResponseAlternativaJson> Execute(RequestRegisterAlternativaJson request);
    }
}
