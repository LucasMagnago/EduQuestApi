using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Usuarios.GetAllByEscolaAndPerfilId
{
    public interface IGetAllUsuarioByEscolaIdAndPerfilIdUseCase
    {
        Task<List<ResponseUsuarioJson>> Execute(int escolaId, int perfilId);
    }
}
