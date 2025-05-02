using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.UsuarioEscolaPerfis.GetAtivoByUsuarioId
{
    public interface IGetUsuarioEscolaPerfilAtivoByUsuarioIdUseCase
    {
        Task<ResponseShortUsuarioEscolaPerfilJson> Execute(int usuarioId);
    }
}
