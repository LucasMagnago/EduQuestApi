using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Usuarios.GetAllByEscolaId
{
    public interface IGetAllUsuarioByEscolaIdUseCase
    {
        Task<List<ResponseUsuarioJson>> Execute(int escolaId);
    }
}
