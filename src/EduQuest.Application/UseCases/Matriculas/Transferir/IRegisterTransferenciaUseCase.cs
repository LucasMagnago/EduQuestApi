using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Matriculas.Transferir
{
    public interface IRegisterTransferenciaUseCase
    {
        Task<ResponseRegisteredTransferenciaJson> Execute(int matriculaId);
    }
}
