using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Escolas.Register
{
    public interface IRegisterEscolaUseCase
    {
        Task<ResponseRegisteredEscolaJson> Execute(RequestRegisterEscolaJson request);
    }
}
