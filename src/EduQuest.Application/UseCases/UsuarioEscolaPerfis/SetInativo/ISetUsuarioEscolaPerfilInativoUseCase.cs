using EduQuest.Communication.Requests;

namespace EduQuest.Application.UseCases.UsuarioEscolaPerfis.SetInativo
{
    public interface ISetUsuarioEscolaPerfilInativoUseCase
    {
        Task Execute(RequestAssignUsuarioJson request);
    }
}
