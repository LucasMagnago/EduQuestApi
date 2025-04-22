using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.PeriodosLetivos.GetAll
{
    public interface IGetAllPeriodoLetivoUseCase
    {
        Task<List<ResponsePeriodoLetivoJson>> Execute();
    }
}
