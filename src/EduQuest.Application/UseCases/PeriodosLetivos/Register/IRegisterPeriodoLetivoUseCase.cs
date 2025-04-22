using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.PeriodosLetivos.Register
{
    public interface IRegisterPeriodoLetivoUseCase
    {
        Task<ResponseRegisteredPeriodoLetivoJson> Execute(RequestRegisterPeriodoLetivoJson request);
    }
}
