using EduQuest.Communication.Requests;

namespace EduQuest.Application.UseCases.UsuarioEscolaPerfis.SetAtivo
{
    public interface ISetUsuarioEscolaPerfilAtivoUseCase
    {
        Task Execute(RequestAssignUsuarioJson request);
    }
}
