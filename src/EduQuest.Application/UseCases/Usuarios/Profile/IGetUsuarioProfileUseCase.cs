using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Usuarios.Profile
{
    public interface IGetUsuarioProfileUseCase
    {
        Task<ResponseUsuarioProfileJson> Execute();
    }
}
