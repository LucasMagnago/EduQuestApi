using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IUsuarioEscolaPerfilRepository
        : IGenericRepository<UsuarioEscolaPerfil>
    {
        Task<List<UsuarioEscolaPerfil>> GetAllByUsuarioIdAsync(int userId);
        Task<List<UsuarioEscolaPerfil>> GetAllByUsuarioGuidAsync(Guid userGuid);

        Task<UsuarioEscolaPerfil> GetActiveByUsuarioIdAsync(int userId);
        Task<UsuarioEscolaPerfil> GetActiveByUsuarioGuidAsync(Guid userGuid);

        Task<bool> DoesUsuarioHavePerfilInEscolaAsync(int userId, int schoolId, int roleId);
        Task<bool> DoesUsuarioHavePerfilInEscolaAsync(Guid userGuid, int schoolId, int roleId);
    }
}
