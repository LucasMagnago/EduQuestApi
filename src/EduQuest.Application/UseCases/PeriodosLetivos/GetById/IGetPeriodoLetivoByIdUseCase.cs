using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.PeriodosLetivos.GetById
{
    public interface IGetPeriodoLetivoByIdUseCase
    {
        Task<ResponsePeriodoLetivoJson> Execute(int id);
    }
}
