using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Alternativas.GetById
{
    public interface IGetAlternativaByIdUseCase
    {
        Task<ResponseAlternativaJson> Execute(int alternativaId);
    }
}
