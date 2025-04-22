using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Escolas.GetById
{
    public interface IGetEscolaByIdUseCase
    {
        Task<ResponseEscolaJson> Execute(int id);
    }
}
