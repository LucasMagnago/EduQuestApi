using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.UsuarioEscolaPerfis.GetAllByUsuarioId
{
    public interface IGetAllUsuarioEscolaPerfilByUsuarioIdUseCase
    {
        Task<List<ResponseShortUsuarioEscolaPerfilJson>> Execute(int usuarioId);
    }
}
