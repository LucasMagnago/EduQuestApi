using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Escolas.GetAll
{
    public interface IGetAllEscolaUseCase
    {
        Task<List<ResponseEscolaJson>> Execute();
    }
}
