using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IUsuarioEscolaPerfilRepository
        : IGenericRepository<UsuarioEscolaPerfil>
    {
        Task<List<UsuarioEscolaPerfil>?> GetAllWithRelations();

        Task<UsuarioEscolaPerfil?> GetByUsuarioIdAndEscolaIdAndPerfilIdAsync(int usuarioId, int escolaId, int perfilId);

        Task<List<UsuarioEscolaPerfil>?> GetAllByUsuarioIdAsync(int usuarioId);
        Task<List<UsuarioEscolaPerfil>?> GetAllByUsuarioGuidAsync(Guid usuarioGuid);

        Task<List<UsuarioEscolaPerfil>?> GetAllWithRelationsByUsuarioIdAsync(int usuarioId);
        Task<List<UsuarioEscolaPerfil>?> GetAllWithRelationsByUsuarioGuidAsync(Guid usuarioGuid);

        Task<UsuarioEscolaPerfil?> GetActiveByUsuarioIdAsync(int usuarioId);
        Task<UsuarioEscolaPerfil?> GetActiveByUsuarioGuidAsync(Guid usuarioGuid);

        Task<UsuarioEscolaPerfil?> GetActiveWithRelationsByUsuarioIdAsync(int usuarioId);
        Task<UsuarioEscolaPerfil?> GetActiveWithRelationsByUsuarioGuidAsync(Guid usuarioGuid);

        Task<bool> DoesUsuarioHavePerfilInEscolaAsync(int usuarioId, int escolaId, int perfilId);
        Task<bool> DoesUsuarioHavePerfilInEscolaAsync(Guid usuarioGuid, int escolaId, int perfilId);
    }
}
