using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Usuarios.GetById
{
    public interface IGetUsuarioByIdUseCase
    {
        Task<ResponseUsuarioJson> Execute(int id);
    }
}
