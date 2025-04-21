using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IUsuarioEscolaPerfilRepository
        : IGenericRepository<UsuarioEscolaPerfil>
    {
        Task<List<UsuarioEscolaPerfil>> GetAllByUsuarioIdAsync(int usuarioId);
        Task<List<UsuarioEscolaPerfil>> GetAllByUsuarioGuidAsync(Guid usuarioGuid);
        Task<UsuarioEscolaPerfil> GetActiveByUsuarioIdAsync(int usuarioId);
        Task<UsuarioEscolaPerfil> GetActiveByUsuarioGuidAsync(Guid usuarioGuid);
    }
}
